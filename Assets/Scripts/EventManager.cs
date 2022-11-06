using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventManager : MonoBehaviour{
    public static event Action OnCreateResource;
    public static void CreateResource() => OnCreateResource?.Invoke();

    public static event Action<Item> OnAddItemToInventory;
    public static void AddItemToInventory(Item item) => OnAddItemToInventory?.Invoke(item);

    public static event Action<bool> OnPermissionRaycastInputController;
    public static void PermissionRaycastInputController(bool permission) => OnPermissionRaycastInputController?.Invoke(permission);


    public static event Action<Item> OnChooseItem;
    public static void ChooseItem(Item item) => OnChooseItem?.Invoke(item);

    public static event Action OnUpdateUIResource;
    public static void UpdateUIResource() => OnUpdateUIResource?.Invoke();

    public static event Action<Item, int> OnSellResource;
    public static void SellResource(Item item, int count) => OnSellResource?.Invoke(item, count);
}
