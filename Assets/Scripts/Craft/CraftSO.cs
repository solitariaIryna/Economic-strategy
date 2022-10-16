using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DataCraft", menuName = "GameData/Crafts")]
public class CraftSO : ScriptableObject{
    [SerializeField] private List<Resource> _useResource;
    [SerializeField] private List<Resource> _createResource;

    public List<Resource> UseResource { get => _useResource; }
    public List<Resource> CreateResource { get => _createResource; }
}
