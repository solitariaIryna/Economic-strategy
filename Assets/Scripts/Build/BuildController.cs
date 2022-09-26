using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildController : MonoBehaviour
{
    [SerializeField] private List<Build> _buildList;
    public Action<Resource> OnGiveResource;
    private TickResource _tickResource;


    private void Awake()
    {
        _buildList = new List<Build>();
        _tickResource = new TickResource();
        _tickResource.Initialize();
    }

    public void AddBuild(Build build)
    {
        _buildList.Add(build);
    }


    public void CreateResourceBuilds(){

    }



    public TickResource ReturnResources()
    {
        _tickResource.Clear();
        for (int i = 0; i < _buildList.Count; i++)
        {
            _tickResource.AddResource(_buildList[i].GetResource());

        }
        return _tickResource;
    }
}
