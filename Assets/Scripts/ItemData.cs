using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory System/Item")]
public class ItemData : ScriptableObject
{
    public int itemID;
    public string itemName;
    [TextArea] public string itemDescription;
    
    public bool isPickedUp;
    
    public Sprite sprite;
    public GameObject itemPrefab;

    public void PickUp()
    {
        isPickedUp = true;
    }
    
    public void Drop()
    {
        isPickedUp = false;
    }
}
