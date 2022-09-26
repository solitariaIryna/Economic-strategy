using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildStore : MonoBehaviour
{
    [SerializeField] private BuildsSO _sawmill;
    [SerializeField] private List<BuildsSO> _builds;
    
    public int GetCountBuilds() => _builds.Count;
    public BuildsSO GetBuild(int index) => _builds[index];   
    public List<BuildsSO> Builds => _builds;
    
    public Build GetModelBuild(TypeBuilds typeBuilds)
    {
        for (int i = 0; i < _builds.Count; i++)
        {
           if (_builds[i].TypeBuilds == typeBuilds)
            {    
                return _builds[i].Build;
            }
           
        }
        return null;
    }
}
