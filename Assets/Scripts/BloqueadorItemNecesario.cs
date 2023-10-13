using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueadorItemNecesario : MonoBehaviour
{
    [SerializeField] private ItemData itemNecesario;
    [SerializeField] private bool consumeElItem;

    private void Start()
    {
        if (itemNecesario.hasBeenUsed)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.collider.name);
        if (other.collider.CompareTag("Player"))
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
