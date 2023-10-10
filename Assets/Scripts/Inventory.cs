using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class Inventory : ScriptableObject
{
    public List<ItemData> items = new List<ItemData>();

    public void AddItem(int id)
    {
        items[id].PickUp();
        Debug.Log("Picked up " + items[id].itemName);
        Debug.Log(items[id].isPickedUp);
    }

    public bool HasItem(int id)
    {
        return items[id].isPickedUp;
    }
    
    public void RemoveItem(int id)
    {
        items[id].Drop();
    }
}
