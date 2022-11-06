using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePanelUI : MonoBehaviour{
    [SerializeField] private RectTransform _panel;
    [SerializeField] private UpdateInformationUI[] _updateInformationUIs;
    
    private void Start(){
        for(int i = 0; i < _updateInformationUIs.Length; i++){
            _updateInformationUIs[i].OnUpdateBuild += UpdateBuild;
        }
    }

    private void OnDisable(){
        for (int i = 0; i < _updateInformationUIs.Length; i++){
            _updateInformationUIs[i].OnUpdateBuild -= UpdateBuild;
        }
    }

    public void OpenPanel(Build build){
        _panel.localScale = Vector3.one;
        SetOpenBuildUpdate(build);
    }

    public void ClosePanel(){
        _panel.localScale = Vector3.zero;
        EventManager.PermissionRaycastInputController(true);
    }

    private void SetOpenBuildUpdate(Build build){
        _updateInformationUIs[0].InitializeUpdateInformation(build.SelectedUpdateBuild, build);
    }

    private void UpdateBuild(UpdateBuildSO updateBuildSO)
    {

    }

}
