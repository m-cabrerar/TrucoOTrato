using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory System/Item")]
public class ItemData : ScriptableObject
{
    public int itemID;
    public string itemName;
    [TextArea] public string itemDescription;
    
    public bool isPickedUp;
    
    public Sprite itemSprite;
    public GameObject itemPrefab;

    public void pickUp()
    {
        isPickedUp = true;
    }
    
    public void drop()
    {
        isPickedUp = false;
    }
}
