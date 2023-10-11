using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    [SerializeField] private Vector3 nuevaPosisionJugador;
    [SerializeField] private Vector3 nuevaRotacionJugador;
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
            SceneManager.LoadScene(escenaACargar);
            cambioDeEscenaRealizado = true;
        }
    }
}