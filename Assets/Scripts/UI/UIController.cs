using System;

using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private UIControllerPanelResource _panelResource;
    [SerializeField] private UIBuildPanel _buildUI;
    public Action<TypeBuilds> OnBuilingType;
    public void Initialize(List<BuildsSO> builds)
    {
        _buildUI.InitializeButton(builds);
        _buildUI.OnBuilingType += BuildingType;
    }
    private void OnDisable()
    {
        _buildUI.OnBuilingType -= BuildingType;
    }

    public void BuildingType(TypeBuilds typeBuilds)
    {
        OnBuilingType?.Invoke(typeBuilds);
    }
    public void ActivePanelButtonBuild()
    {
        _buildUI.ActivePanelButton();
    }

    public void UpdateValueResource(){
        _panelResource.UpdateValueResource();
    }
    
}
