using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DataUpdate", menuName = "GameData/Updates")]
public class UpdateBuildSO : ScriptableObject{
    [SerializeField] private string _nameUpdate;
    [SerializeField] private Sprite _image;
    [SerializeField] private List<SettingUpdate> _settingUpdates;
    [SerializeField] private TypeBuilds _typeBuilds;
    [SerializeField] private int _levelUpdate;
    [SerializeField] private int _priceUpdate;
    
    public TypeBuilds TypeBuilds { get => _typeBuilds; }
    public int LevelUpdate { get => _levelUpdate; }
    public string NameUpdate { get => _nameUpdate;}
    public Sprite Image { get => _image; }
    public List<SettingUpdate> SettingUpdates { get => _settingUpdates; }
    public int PriceUpdate { get => _priceUpdate; }

    public void UpdateUP(){
        _levelUpdate++;
        _priceUpdate += 20;
        for (int i = 0; i < _settingUpdates.Count; i++){
            if (_settingUpdates[i]._typeEffectUpdate == TypeEffectUpdate.CountCreate){
                _settingUpdates[i]._value++;
            }

            if (_settingUpdates[i]._typeEffectUpdate == TypeEffectUpdate.SpeedCreate){
                _settingUpdates[i]._value += 3f;
            }
        }
    }
}
