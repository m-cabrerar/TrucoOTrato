using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueadorItemNecesario : MonoBehaviour
{
    [SerializeField] private ItemData itemNecesario;
    [SerializeField] private bool consumeElItem;
    [SerializeField] [TextArea] private string dialogo = "";

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
            if (dialogo != "")
                DialogoController.Instance.MostrarDialogo(dialogo);
            
            Destroy(gameObject);
        }
    }
}
