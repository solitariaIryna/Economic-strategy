
using System.Collections.Generic;
using UnityEngine;

public class UIControllerPanelResource : MonoBehaviour
{
    [SerializeField] private List<PanelResourceUI> _panels;


    public void UpdateValueResource(){
        for (int i = 0; i < _panels.Count; i++)
        {
            _panels[i].ChangeCount(Storage.instance.GetResourceToType(_panels[i].GetTypeResourcesPanel()).Value);
        }


    }
}
