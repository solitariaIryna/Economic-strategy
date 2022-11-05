
using System;
using UnityEngine;

public class Build : MonoBehaviour{
    [SerializeField] private string _name;
    [SerializeField] private UIBuildController _UIBuildController;
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

    public void UpdateBuild(){
        CreateResource();
    }


    public UpdateBuildSO[] UpdateBuilds { get => _updateBuilds; set => _updateBuilds = value; }
    private void CreateValueResource(){
        _resource = new Resource(_craftSO.CreateResource[0].Resources, _countTick);
        _timerCreateResource = 0f;
    }

    public virtual void Initialize(){
        CreateValueResource();
        _UIBuildController.SetNameBuild(_name);
        _UIBuildController.SetResourceData(_craftSO.ImageResource, _countTick);
        _UIBuildController.SetProgressBarData(_timeCreateResource);
    }
    public virtual Resource GetResource(){
        return _resource;
    }

    public virtual void CreateResource() {
        if (_timerCreateResource <= _timeCreateResource){
            _timerCreateResource += Time.deltaTime;
        }    
        else{
            _timerCreateResource = 0f;
            Storage.instance.AddResources(_resource);
            EventManager.CreateResource();
            //OnCreateResource?.Invoke(_resource);
        }
        _UIBuildController.ChangeProgressCreateResource(_timerCreateResource);
    }

    public virtual void UpdateOpen(UpdateBuildSO updateBuildSO){
        _selectedUpdateBuild = updateBuildSO;
        CalculationResource();
        _UIBuildController.SetUpgradeData(_selectedUpdateBuild.Image, _selectedUpdateBuild.LevelUpdate);
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
        _UIBuildController.SetResourceData(_craftSO.ImageResource, _resource.Value);
        _UIBuildController.SetProgressBarData(_timeCreateResource);
    }

    




}
