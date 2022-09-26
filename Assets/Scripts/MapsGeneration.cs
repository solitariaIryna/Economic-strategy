using System;
using System.Collections.Generic;
using UnityEngine;

public class MapsGeneration : MonoBehaviour
{
    [SerializeField] private Cell cell;
    [SerializeField] private List<Cell> cells;
    private int width = 6;
    private int height = 6;
    public Action<List<Cell>> OnCompleteGenerate;


    public void GenerationMap()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Cell InstantiateCell = Instantiate(cell);
                InstantiateCell.transform.position = new Vector3(i * 10, 0, j * 10);
                cells.Add(InstantiateCell);
            }
        }
        OnCompleteGenerate?.Invoke(cells);
    }

    void Start()
    {
        cells = new List<Cell>();
        
    }

}
