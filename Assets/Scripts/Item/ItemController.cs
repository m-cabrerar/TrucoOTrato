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
        if (!other.CompareTag("Player")) return;
        if (DialogoController.Instance.Mostrado(itemData.dialogoNecesario))
        {
            PickUp();
            DialogoController.Instance.MostrarDialogo(itemData.dialogoOnPickUp, gameObject.name + "OnPickUp");
        }
        else 
            DialogoController.Instance.MostrarDialogo(itemData.dialogoOnInspect, gameObject.name + "OnInspect");

    }

    private void PickUp()
    {
        InventoryController.Instance.AddItem(itemData);
        Destroy(gameObject);
    }
}
