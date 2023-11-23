using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetornoAlMenu : MonoBehaviour
{
    [SerializeField] private Escena _escenaObjetivo = Escena.MENU;
    [SerializeField] private int _tiempoDeEspera = 10;

    void Start()
    {
        StartCoroutine(EsperaYCambioDeEscena());
    }

    IEnumerator EsperaYCambioDeEscena()
    {
        yield return new WaitForSeconds(_tiempoDeEspera);
        TransitionScreen.Instance.TransitionTo(_escenaObjetivo);
    }
}
