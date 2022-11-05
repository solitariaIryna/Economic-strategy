
using System;
using UnityEngine;
using UnityEngine.UI;

public class PanelBuildUI : MonoBehaviour
{
    [SerializeField] private Text _nameBuild;
    [SerializeField] private Text _costBuild;
    [SerializeField] private Image _image;
    [SerializeField] private Button _button;
    [SerializeField] private TypeBuilds _type;
    public Action<TypeBuilds> OnClickButton;

    public void InitializationPanel(BuildsSO buildsSO){
        _nameBuild.text = buildsSO.NameModel;
        _costBuild.text = buildsSO.Cost.ToString();
        _image.sprite = buildsSO.Sprite;
        _type = buildsSO.TypeBuilds;
    }

    public void ClickButton() => OnClickButton?.Invoke(_type);
        
}
