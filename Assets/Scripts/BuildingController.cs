
using System;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    private Cell _cell;
    public Action<Build> OnAddBuildList;
    public void BuildBuilding(Build build)
    {
        Build building = Instantiate(build);
        building.Initialize();
        building.transform.position = _cell.PointCenter.position;
        _cell.IsBuild = true;
        OnAddBuildList?.Invoke(building);

    }
    public void CellforBuilding(Cell cell)
    {
        _cell = cell;
    }


}
