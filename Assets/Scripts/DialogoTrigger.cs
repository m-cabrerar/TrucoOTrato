using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoTrigger : MonoBehaviour
{

    [SerializeField] private Dialogo dialogo;
    private void Start()
    {
        if (dialogo.mostrarUnaVez && DialogoController.Instance.Mostrado(gameObject.name))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DialogoController.Instance.MostrarDialogo(dialogo, gameObject.name);
            if (dialogo.mostrarUnaVez) Destroy(gameObject);
        }
    }
}
