using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bloqueador : MonoBehaviour
{
    [SerializeField] private Dialogo dialogoOnInspect;
    [SerializeField] private Dialogo dialogoOnUse;
    [SerializeField] protected GameObject spawnOnUse;

    private void OnCollisionEnter(Collision other)
    {
        if (!other.collider.CompareTag("Player")) return;
        if (cumpleRequisito())
        {
            Destroy(gameObject);
            DialogoController.Instance.MostrarDialogo(dialogoOnUse, gameObject.name + "OnUse");
            if (spawnOnUse != null) spawnOnUse.SetActive(true);
        }
        else
            DialogoController.Instance.MostrarDialogo(dialogoOnInspect, gameObject.name + "OnInspect");
    }

    protected abstract bool cumpleRequisito();
}