
using UnityEngine;

public struct TickResource
{
    [SerializeField] private Resource[] _resources;

    public void Initialize()
    {
        _resources = new Resource[4];
        Resource wood = new Resource(Resources.Wood, 0);
        Resource gold = new Resource(Resources.Gold, 0);
        Resource food = new Resource(Resources.Food, 0);
        Resource metal = new Resource(Resources.Metal, 0);

        _resources[0] = wood;
        _resources[1] = gold;
        _resources[2] = food;
        _resources[3] = metal;
    }

    public void AddResource(Resource resource)
    {
        for (int i = 0; i < _resources.Length; i++)
        {
            if (_resources[i].Resources == resource.Resources)
            {
                _resources[i].Value += resource.Value;
            }
        }
    }
    public void Clear()
    {
        for (int i = 0; i < _resources.Length; i++)
        {
            _resources[i].ClearValueResource();
        }
    }

    public int GetCountResource()
    {
        return _resources.Length;
    }
    public Resource GetResourceToIndex(int index)
    {
        return _resources[index];
    }
}