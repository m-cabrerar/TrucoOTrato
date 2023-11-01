using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] private ItemData itemData;
    
    private void Start()
    {
        if (InventoryController.Instance.HasItem(itemData) 
        || InventoryController.Instance.FueConsumido(itemData))
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            PickUp();
    }

    private void PickUp()
    {
        if (itemData.itemDescription != "") 
            DialogoController.Instance.MostrarDialogo(itemData.itemDescription);
        InventoryController.Instance.AddItem(itemData);
        Destroy(gameObject);
    }
}
