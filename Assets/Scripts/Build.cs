
using System;
using UnityEngine;

public class Build : MonoBehaviour{
    [SerializeField] private UpdateBuildSO[] _updateBuilds;
    [SerializeField] private UpdateBuildSO _selectedUpdateBuild;
    [SerializeField] private CraftSO _craftSO;
    [SerializeField] private Resources _resources;
    [SerializeField] private Resource _resource;
    [SerializeField] private int _countTick;
    [SerializeField] private float _timeCreateResource;
    private float _timerCreateResource;
    public Action<Resource> OnCreateResource;
    [SerializeField] private bool _isCheckValueResource;

    public void Update(){
        if(_isCheckValueResource)
        {
            _isCheckValueResource = false;
            Debug.Log("Value:" + _resource.Value);
        }
    }


    public UpdateBuildSO[] UpdateBuilds { get => _updateBuilds; set => _updateBuilds = value; }
    private void CreateValueResource(){
        _resource = new Resource(_craftSO.CreateResource[0].Resources, _countTick);
        _timerCreateResource = 0f;
    }

    public virtual void Initialize(){
        CreateValueResource();
        
    }
    public virtual Resource GetResource(){
        return _resource;
    }

    public virtual void CreateResource() {
        if (_timerCreateResource <= _timeCreateResource)
            _timerCreateResource += Time.deltaTime;
        else
        {
            _timerCreateResource = 0f;
            OnCreateResource?.Invoke(_resource);
        }

    }

    public virtual void UpdateOpen(UpdateBuildSO updateBuildSO){
        _selectedUpdateBuild = updateBuildSO;
        CalculationResource();
    }

    public virtual void CalculationResource(){
        for (int i = 0; i < _selectedUpdateBuild.SettingUpdates.Count; i++){
            if (_selectedUpdateBuild.SettingUpdates[i]._typeEffectUpdate == TypeEffectUpdate.CountCreate){
                _resource.Value = _resource.Value + (int)_selectedUpdateBuild.SettingUpdates[i]._value;
            }

            if(_selectedUpdateBuild.SettingUpdates[i]._typeEffectUpdate == TypeEffectUpdate.SpeedCreate){
                _timeCreateResource = _timeCreateResource - (_timeCreateResource / 100f) * _selectedUpdateBuild.SettingUpdates[i]._value;
            }
        }

      
      
    }

    




}
