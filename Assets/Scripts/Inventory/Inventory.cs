using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField] private List<ItemData> items = new List<ItemData>();
    private List<ItemData> itemsInventory = new List<ItemData>();

    // public void AddItem(int id)
    // {
    //     items[id].PickUp();
    //     itemsInventory.Add(items[id]);
    // }
    public void AddItem(ItemData itemData)
    {
        itemData.PickUp();
        itemsInventory.Add(itemData);
    }

    public bool HasItem(ItemData item)
    {
        return itemsInventory.Contains(item);
    }
    
    public void RemoveItem(ItemData itemData)
    {
        itemData.Drop();
        itemsInventory.Remove(itemData);
    }

    public List<ItemData> GetItems()
    {
        return itemsInventory;
    }
}
