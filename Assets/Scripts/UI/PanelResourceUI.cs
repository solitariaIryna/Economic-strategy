
using UnityEngine;
using UnityEngine.UI;

public class PanelResourceUI : MonoBehaviour
{
    [SerializeField] private Text _countText;
    [SerializeField] private Resources _resources;

    public Resources GetTypeResourcesPanel() => _resources;
    public void ChangeCount(float count)
    {
        _countText.text = count.ToString();
    }
}
