using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    
    [SerializeField] private Cell _cell;
    [SerializeField] private Build _selectedBuild;
    
    public Action<Cell> OnChooseCell;
    
    public Action<Build> OnChooseBuild;

    private bool _permissionOnRaycast = true;

    private void Start(){
        EventManager.OnPermissionRaycastInputController += StatePermisionRaycast;
    }

    private void OnDisable(){
        EventManager.OnPermissionRaycastInputController -= StatePermisionRaycast;
    }



    private Vector3 CalculationDirectionToPoint()
    {

        Vector2 screenpos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 positionClick = Input.mousePosition;

        Vector3 world = Vector3.zero;
            //new Vector3(positionClick.y / Screen.height, -1, positionClick.x / Screen.width ).normalized;
        // Vector3 positionSpawnPoint = Camera.main.ViewportToWorldPoint(new Vector3(world.x, world.y, 1));
        var plane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out float position))
        {
            Vector3 worldposition = ray.GetPoint(position);
            world = (worldposition - transform.position).normalized;
        }
        

        return world;
    }

    private void RaycastPoint(Vector3 direction){
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, Mathf.Infinity)){
            Debug.Log(hit.collider.name);
            Cell _tempcell = hit.collider.GetComponent<Cell>();
            if (_tempcell.IsBuild == false){
                CheckCell(_tempcell);
                _tempcell.Activate();
                OnChooseCell?.Invoke(_cell);
            }
            else{
                Debug.Log("Build:" + _tempcell.Build.name);
                OnChooseBuild?.Invoke(_tempcell.Build);
                _selectedBuild = _tempcell.Build;
            }
        }
    }

    private void CheckCell(Cell newCell){
        if (_cell == null)
            _cell = newCell;

        if (newCell != _cell){ 
            _cell.DisActivate();
            _cell = newCell;
        }
    }
    
    void Update(){
        if (Input.GetMouseButtonDown(0) && _permissionOnRaycast){   
            RaycastPoint(CalculationDirectionToPoint());
        }
    }

    public void StatePermisionRaycast(bool state){
        _permissionOnRaycast = state;
    }

    public Build GetSelectedBuild() => _selectedBuild;
}
