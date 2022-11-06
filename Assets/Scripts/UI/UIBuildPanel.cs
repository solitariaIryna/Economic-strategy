using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBuildPanel : MonoBehaviour
{
  
    [SerializeField] private List<PanelBuildUI> buildUIList;
    [SerializeField] private RectTransform _panelBottom;
    public Action<TypeBuilds> OnBuilingType;

    private void Start()
    {
        for (int i = 0; i < buildUIList.Count; i++)
        {
            buildUIList[i].OnClickButton += SetTypeBuildingBuild;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < buildUIList.Count; i++)
        {
            buildUIList[i].OnClickButton -= SetTypeBuildingBuild;
        }
    }
    private void SetTypeBuildingBuild(TypeBuilds type)
    {
        OnBuilingType?.Invoke(type);
        DisablePanelButton();
    }

    public void InitializeButton(List<BuildsSO> builds){
        for (int i = 0; i < builds.Count; i++){
            buildUIList[i].InitializationPanel(builds[i]);
        }
    }

    public void ActivePanelButton()
    {
        _panelBottom.localScale = Vector3.one;
    }

    public void DisablePanelButton()
    {
        _panelBottom.localScale = Vector3.zero;
        EventManager.PermissionRaycastInputController(true);
    }
}
