
using System.Collections.Generic;
using UnityEngine;

public class MapsController : MonoBehaviour
{
    [SerializeField] private MapsGeneration _maps;
    [SerializeField] private List<Cell> _map;



    private void SetMap(List<Cell> map)
    {
        _map.AddRange(map);
    }
    void Start()
    {
        _map = new List<Cell>();
        _maps.OnCompleteGenerate += SetMap;
        _maps.GenerationMap();
    }
    private void OnDisable()
    {
        _maps.OnCompleteGenerate -= SetMap;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
