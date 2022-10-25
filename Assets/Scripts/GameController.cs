using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private UIController _uiController;
    [SerializeField] private BuildStore _buildStore;
    [SerializeField] private InputController _inputController;
    [SerializeField] private BuildingController _buildingController;
    [SerializeField] private Storage _storage;
    [SerializeField] private BuildController _buildController;
    private float _timer;
    private void Start()
    {
        _inputController.OnChooseCell += SetCell;
        _inputController.OnChooseBuild += SetBuild;
        _uiController.OnBuilingType += SetTypeBuilding;
        _buildingController.OnAddBuildList += NewBuildingBuild;

        Storage.instance.Initialize();
        _uiController.Initialize(_buildStore.Builds);

    }
    private void OnDisable()
    {
        _inputController.OnChooseCell -= SetCell;
        _inputController.OnChooseBuild -= SetBuild;
        _buildingController.OnAddBuildList -= NewBuildingBuild;
        _uiController.OnBuilingType -= SetTypeBuilding;
    }
    private void SetCell(Cell cell)
    {
        _buildingController.CellforBuilding(cell);
        _uiController.ActivePanelButtonBuild();
        _inputController.StatePermisionRaycast(false);
    }

    private void SetBuild(Build build){
        _uiController.OpenUpdatePanel(build);
    }


    private void SetTypeBuilding(TypeBuilds typeBuilds)
    {
       _buildingController.BuildBuilding(_buildStore.GetModelBuild(typeBuilds));
        _inputController.StatePermisionRaycast(true);
        
    }
    private void Update()
    {
        if (_timer <= 1f)
        {
            _timer += Time.deltaTime;
        }
        else
        {
            Storage.instance.AddResources(_buildController.ReturnResources());
            _uiController.UpdateValueResource();
            _timer = 0f;

        }
    }

    private void NewBuildingBuild(Build building)
    {
        _buildController.AddBuild(building);

    }
}
