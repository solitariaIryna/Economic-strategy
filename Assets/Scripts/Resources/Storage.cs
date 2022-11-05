
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    [SerializeField] private List<Resource> _resources;
    static public Storage instance;

    private void Awake()
    {
        instance = this;
    }

    public void Initialize()
    {
        _resources = new List<Resource>();
        Resource wood = new Resource(Resources.Wood, 0);
        Resource gold = new Resource(Resources.Gold, 0);
        Resource food = new Resource(Resources.Food, 0);
        Resource metal = new Resource(Resources.Metal, 0);

        _resources.Add(wood);
        _resources.Add(gold);
        _resources.Add(food);
        _resources.Add(metal);
    }

    public void AddResource(Resource resource)
    {

    }

    public void AddResources(Resource resource){
        for(int i = 0; i < _resources.Count; i++){
            if(resource._resources == _resources[i]._resources){
                _resources[i].Value += resource.Value;
            }
        }
    }

    //for( int i = 0; i < tickResource.GetCountResource(); i++)
    //{
    //    for(int j = 0; j < _resources.Count; j++)
    //    {
    //        if (tickResource.GetResourceToIndex(i).Resources == _resources[j].Resources)
    //        {
    //            _resources[j].Value += tickResource.GetResourceToIndex(i).Value;
    //        }
    //    }
    //}


    public int GetCountResource()
    {
        return _resources.Count;
    }
    public Resource GetResourceToIndex(int index)
    {
        return _resources[index];
    }

    public Resource GetResourceToType(Resources resources){
        for (int i = 0; i < _resources.Count; i++){
            if (_resources[i].Resources == resources)
                return _resources[i];
        }
        return null; ;
    }
}
