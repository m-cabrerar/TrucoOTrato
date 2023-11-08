using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory System/Item")]
public class ItemData : ScriptableObject
{
    public int itemID;
    public string itemName;
    public string dialogoNecesario = DialogoController.MOSTRAR_SIEMPRE;
    [SerializeField] public Dialogo dialogoOnInspect;
    [SerializeField] public Dialogo dialogoOnPickUp;
    
    public bool isPickedUp;
    // public bool hasBeenUsed;
    
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
