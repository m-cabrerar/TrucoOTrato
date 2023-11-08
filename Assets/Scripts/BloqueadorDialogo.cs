using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueadorDialogo : Bloqueador
{
    [SerializeField] private string dialogoNecesario;
    private void Start()
    {
        if (dialogoNecesario.Equals(DialogoController.MOSTRAR_SIEMPRE))
        {
            Debug.Log($"El bloqueador {this} no tiene especificado su Dialogo Necesario. Agregarlo!");
        }

        if (DialogoController.Instance.Mostrado(dialogoNecesario))
        {
            Destroy(gameObject);
        }
    }
    
    protected override bool cumpleRequisito()
    {
        return DialogoController.Instance.Mostrado(dialogoNecesario);
    }
}
