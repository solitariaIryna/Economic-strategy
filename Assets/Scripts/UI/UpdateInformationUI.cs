using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateInformationUI : MonoBehaviour{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private List<Text> _textUpdates;
    [SerializeField] private Image _spriteUpdate;
    [SerializeField] private Text _textNameUpdate;
    [SerializeField] private Button _button;
    [SerializeField] private UpdateBuildSO _currentUpdate;
    [SerializeField] private Build _currentUpdateBuild;
    public Action<UpdateBuildSO> OnUpdateBuild;
    private void Start(){
        _button.onClick.AddListener(UpdateBuild);
        ClosePanel();
    }
    private void OnDisable(){
        _button.onClick.RemoveListener(UpdateBuild);
    }
    public void InitializeUpdateInformation(UpdateBuildSO updateBuildSO, Build build){
        OpenPanel();
        _currentUpdate = updateBuildSO;
        _currentUpdateBuild = build;
        _spriteUpdate.sprite = updateBuildSO.Image;
        _textNameUpdate.text = updateBuildSO.NameUpdate;
        for(int i = 0; i < updateBuildSO.SettingUpdates.Count; i++){
            _textUpdates[i].text = updateBuildSO.SettingUpdates[i]._typeEffectUpdate + ":" + updateBuildSO.SettingUpdates[i]._value;
        }
    }
    public void UpdateBuild(){
        _currentUpdate.OpenUpdate = true;
        _currentUpdateBuild.UpdateOpen(_currentUpdate);
        ClosePanel();
    }

    private void OpenPanel(){
        _rectTransform.localScale = Vector3.one;
    }

    private void ClosePanel(){
        _rectTransform.localScale = Vector3.zero;
    }


}
