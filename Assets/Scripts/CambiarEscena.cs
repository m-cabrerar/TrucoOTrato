using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    [SerializeField] private Vector3 nuevaPosisionJugador;
    [SerializeField] private Vector3 nuevaRotacionJugador;
    [SerializeField, Tooltip("En caso de ser NONE, se ira a la escena con el indice Escena A Cargar")]
    private Escena nombreEscenaACargar = Escena.NONE;
    [SerializeField] private int escenaACargar;

    private bool cambioDeEscenaRealizado = false;

    /*private void Start()
    {
        cambioDeEscenaRealizado = true;
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (!cambioDeEscenaRealizado && other.CompareTag("Player"))
        {
            PlayerData.Instance.playerPosition = nuevaPosisionJugador;
            PlayerData.Instance.playerRotation = Quaternion.Euler(nuevaRotacionJugador);
            if (nombreEscenaACargar == Escena.NONE)
            {
                SceneManager.LoadScene(escenaACargar);
            }
            else
            {
                SceneManager.LoadScene((int)nombreEscenaACargar);
            }
            cambioDeEscenaRealizado = true;
        }
    }
}