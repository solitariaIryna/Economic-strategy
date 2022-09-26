
using System;
using UnityEngine;

public class Build : MonoBehaviour
{
    [SerializeField] private Resources _resources;
    private Resource _resource;
    [SerializeField] private int _countTick;
    [SerializeField] private float _timeCreateResource;
    private float _timerCreateResource;
    public Action<Resource> OnCreateResource; 
    
    private void CreateValueResource()
    {
        _resource = new Resource(_resources, _countTick);
        _timerCreateResource = 0f;
    }

    public virtual void Initialize()
    {
        CreateValueResource();
        
    }
    public virtual Resource GetResource()
    {
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
}
