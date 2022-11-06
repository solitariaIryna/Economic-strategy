using UnityEngine;

public class Inventory : ItemContainer
{
	[SerializeField] protected Item[] startingItems;
	[SerializeField] protected Transform itemsParent;

	//protected override void OnValidate()
	//{
	//	if (itemsParent != null)
	//		itemsParent.GetComponentsInChildren(includeInactive: true, result: ItemSlots);

		
	//}

	protected override void Awake(){
		base.Awake();
		
	}

	

}
