using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateBuildController : MonoBehaviour{
    [SerializeField] private UpdateBuildSO[] _updateBuild;
    public int GetCountUpdate(){
        return _updateBuild.Length;
    }
    public UpdateBuildSO GetUpdateBuild(int index){
        return _updateBuild[index];
    }
}
