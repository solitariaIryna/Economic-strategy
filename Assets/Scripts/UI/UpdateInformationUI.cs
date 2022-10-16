using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateInformationUI : MonoBehaviour{
    [SerializeField] private List<Text> _textUpdates;
    [SerializeField] private Image _spriteUpdate;
    [SerializeField] private Text _textNameUpdate;
    [SerializeField] private Button _button;


    public void InitializeUpdateInformation(UpdateBuildSO updateBuildSO){
        _spriteUpdate.sprite = updateBuildSO.Image;
        _textNameUpdate.text = updateBuildSO.NameUpdate;
        for(int i = 0; i < updateBuildSO.SettingUpdates.Count; i++){
            _textUpdates[i].text = updateBuildSO.SettingUpdates[i]._typeEffectUpdate + ":" + updateBuildSO.SettingUpdates[i]._value;
        }
    }
    
}
