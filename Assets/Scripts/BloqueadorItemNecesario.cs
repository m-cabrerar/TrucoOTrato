using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueadorItemNecesario : Bloqueador
{
    [SerializeField] private ItemData itemNecesario;
    [SerializeField] private bool consumeElItem;

    private void Start()
    {
        if (itemNecesario == null)
        {
            Debug.Log($"El bloqueador {this} no tiene especificado su Item Necesario. Agregarlo!");
            return;
        }

        if (InventoryController.Instance.FueConsumido(itemNecesario))
        {
            Destroy(gameObject);
            if (spawnOnUse != null) spawnOnUse.SetActive(true);
        }
        else
        {
            if (spawnOnUse != null) spawnOnUse.SetActive(false);
        }
    }
    
    protected override bool cumpleRequisito()
    {
        return InventoryController.Instance.TratarDeUsarItem(itemNecesario, consumeElItem);
    }
}
