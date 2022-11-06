using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemContainer : MonoBehaviour, IItemContainer
{
	public List<ItemSlot> ItemSlots;
	[SerializeField] private RectTransform panel;
	public event Action<BaseItemSlot> OnPointerEnterEvent;
	public event Action<BaseItemSlot> OnPointerExitEvent;
	public event Action<BaseItemSlot> OnRightClickEvent;
	public event Action<BaseItemSlot> OnBeginDragEvent;
	public event Action<BaseItemSlot> OnEndDragEvent;
	public event Action<BaseItemSlot> OnDragEvent;
	public event Action<BaseItemSlot> OnDropEvent;

	//protected virtual void OnValidate()
	//{
	//	GetComponentsInChildren(includeInactive: true, result: ItemSlots);
	//}

	protected virtual void Awake(){
		EventManager.OnAddItemToInventory += AddItem;
		EventManager.OnSellResource += RemoveItem;
		for (int i = 0; i < ItemSlots.Count; i++){
			ItemSlots[i].OnPointerEnterEvent += slot => EventHelper(slot, OnPointerEnterEvent);
			ItemSlots[i].OnPointerExitEvent += slot => EventHelper(slot, OnPointerExitEvent);
			ItemSlots[i].OnRightClickEvent += slot => EventHelper(slot, OnRightClickEvent);
			ItemSlots[i].OnBeginDragEvent += slot => EventHelper(slot, OnBeginDragEvent);
			ItemSlots[i].OnEndDragEvent += slot => EventHelper(slot, OnEndDragEvent);
			ItemSlots[i].OnDragEvent += slot => EventHelper(slot, OnDragEvent);
			ItemSlots[i].OnDropEvent += slot => EventHelper(slot, OnDropEvent);
		}
	}

    private void OnDisable(){
		EventManager.OnAddItemToInventory -= AddItem;
		EventManager.OnSellResource -= RemoveItem;
	}



    private void EventHelper(BaseItemSlot itemSlot, Action<BaseItemSlot> action){
		if (action != null)
			action(itemSlot);
	}

	public virtual bool CanAddItem(Item item, int amount = 1){
		int freeSpaces = 0;

		foreach (ItemSlot itemSlot in ItemSlots)
		{
			if (itemSlot.Item == null || itemSlot.Item.ID == item.ID)
			{
				freeSpaces += item.MaximumStacks - itemSlot.Amount;
			}
		}
		return freeSpaces >= amount;
	}

	public virtual void AddItem(Item item){
		for (int i = 0; i < ItemSlots.Count; i++)
		{
			if(ItemSlots[i].Item == null){
				ItemSlots[i].Item = item.GetCopy();
				ItemSlots[i].Amount = ItemSlots[i].Item.Value;
				break;
			}
            else{
				if(ItemSlots[i].Item.TypeItem == item.TypeItem){
					ItemSlots[i].Item.Value += item.Value;
					ItemSlots[i].Amount = ItemSlots[i].Item.Value;
					break;
				}

            }
		}
	}

	public virtual bool RemoveItem(Item item)
	{
		for (int i = 0; i < ItemSlots.Count; i++)
		{
			if (ItemSlots[i].Item == item)
			{
				ItemSlots[i].Amount--;
				return true;
			}
		}
		return false;
	}

	public virtual Item RemoveItem(string itemID)
	{
		for (int i = 0; i < ItemSlots.Count; i++)
		{
			Item item = ItemSlots[i].Item;
			if (item != null && item.ID == itemID)
			{
				ItemSlots[i].Amount--;
				return item;
			}
		}
		return null;
	}

	

	public virtual int ItemCount(string itemID)
	{
		int number = 0;

		for (int i = 0; i < ItemSlots.Count; i++)
		{
			Item item = ItemSlots[i].Item;
			if (item != null && item.ID == itemID)
			{
				number += ItemSlots[i].Amount;
			}
		}
		return number;
	}

	public void Clear()
	{
		for (int i = 0; i < ItemSlots.Count; i++)
		{
			if (ItemSlots[i].Item != null && Application.isPlaying) {
				ItemSlots[i].Item.Destroy();
			}
			ItemSlots[i].Item = null;
			ItemSlots[i].Amount = 0;
		}
	}

	public void CloseWindow(){
		panel.localScale = Vector3.zero;
		EventManager.PermissionRaycastInputController(true);
	}

	public void OpenWindow(){
		panel.localScale = Vector3.one;
		EventManager.PermissionRaycastInputController(false);
	}

	public void RemoveItem(Item itemSelected, int count)
	{
		for (int i = 0; i < ItemSlots.Count; i++)
		{
			if (ItemSlots[i].Item == itemSelected)
			{
				ItemSlots[i].Item.Value -= count;
				ItemSlots[i].Amount = ItemSlots[i].Item.Value;
				break;
			}
		}
	}
}
