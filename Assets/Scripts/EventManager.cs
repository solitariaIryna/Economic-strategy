using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventManager : MonoBehaviour{
    public static event Action OnCreateResource;
    public static void CreateResource() => OnCreateResource?.Invoke();

    public static event Action<bool> OnPermissionRaycastInputController;
    public static void PermissionRaycastInputController(bool permission) => OnPermissionRaycastInputController?.Invoke(permission);
}
