using UnityEngine;
using UnityEngine.UI;

public class UIBuildController : MonoBehaviour{
    [SerializeField] private Image _upgradeBuildImage;   
    [SerializeField] private Text _upgradeBuildLevel;   
    [SerializeField] private Text _buildName;
    [SerializeField] private Slider _progressBarCreateResource;
    [SerializeField] private Image _resourceCreateImage;
    [SerializeField] private Text _countCreateResource;

    public void SetNameBuild(string nameBuild){
        _buildName.text = nameBuild;
    }

    public void SetResourceData(Sprite resource, int countCreateResource){
        _resourceCreateImage.sprite = resource;
        _countCreateResource.text = countCreateResource.ToString();
    }

    public void SetProgressBarData(float timeCraft){
        _progressBarCreateResource.maxValue = timeCraft;
        _progressBarCreateResource.value = 0f;
    }

    public void ChangeProgressCreateResource(float value){
        _progressBarCreateResource.value = value;
    }

    public void SetUpgradeData(Sprite upgrade, int levelUpgrade){
        _upgradeBuildLevel.text = levelUpgrade.ToString();
    } 
}
