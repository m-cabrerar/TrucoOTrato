using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueadorItemNecesario : MonoBehaviour
{
    [SerializeField] private ItemData itemNecesario;
    [SerializeField] private bool consumeElItem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CheckItemToUse();
        }
    }

    private void CheckItemToUse()
    {
        bool sePudoUsar = InventoryController.Instance.TratarDeUsarItem(itemNecesario, consumeElItem);
        if (sePudoUsar)
        {
            Destroy(gameObject);
        }
    }
}
