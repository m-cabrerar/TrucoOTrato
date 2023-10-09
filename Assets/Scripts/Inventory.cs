using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class Inventory : ScriptableObject
{
    public const int SLOTS = 8;
    public Dictionary<int, ItemData> items = new Dictionary<int, ItemData>();

    public void AddItem(int id)
    {
        items[id].pickUp();
    }
    
    public bool hasItem(int id)
    {
        return items[id].isPickedUp;
    }
    
    public void RemoveItem(int id)
    {
        items[id].drop();
    }
}
