using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] private ItemData itemData;
    
    public void PickUp(Inventory inventory)
    {
        inventory.AddItem(itemData);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InventoryController inventoryController = other.GetComponent<InventoryController>();
            PickUp(inventoryController.GetInventory());
        }
    }
}
