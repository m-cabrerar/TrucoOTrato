using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemController : MonoBehaviour
{
    [SerializeField] private ItemData itemData;
    [SerializeField] private Inventory inventory;
    
    public void PickUp()
    {
        inventory.AddItem(itemData.itemID);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp();
        }
    }
}
