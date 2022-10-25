using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePanelUI : MonoBehaviour{
    [SerializeField] private Image _panel;
    [SerializeField] private UpdateInformationUI[] _updateInformationUIs;
    
    private void Start(){
        for(int i = 0; i < _updateInformationUIs.Length; i++){
            _updateInformationUIs[i].OnUpdateBuild += UpdateBuild;
        }
    }

    private void OnDisable(){
        for (int i = 0; i < _updateInformationUIs.Length; i++)
        {
            _updateInformationUIs[i].OnUpdateBuild -= UpdateBuild;
        }
    }





    public void OpenPanel(Build build){
        _panel.enabled = true;
        SetOpenBuildUpdate(build);
    }

    private void ClosePanel(){
        _panel.enabled = false;
    }


    private void SetOpenBuildUpdate(Build build){
        for(int i = 0; i < build.UpdateBuilds.Length; i++){
            _updateInformationUIs[i].InitializeUpdateInformation(build.UpdateBuilds[i], build);
        }
    }


    private void UpdateBuild(UpdateBuildSO updateBuildSO)
    {

    }

}
