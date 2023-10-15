using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Vector3 nuevaPosisionJugador;

    [SerializeField] bool enEspera = false;
    private Collider portalCollider;
    private Collider playerCollider;

    private void Awake()
    {
        portalCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        float distancia = Vector3.Distance(other.transform.position, transform.position);
        if (!other.CompareTag("Player")) return;
        playerCollider = other.GetComponent<Collider>();
        if (distancia >= 0.25f)
        {
            RealizarTeletransporte(other.transform);
        }
        else
        {
            StartCoroutine(Esperar(3f, other.transform));
        }
    }

    private void RealizarTeletransporte(Transform player)
    {
        player.position = nuevaPosisionJugador;
    }

    private IEnumerator Esperar(float tiempo, Transform player)
    {
        yield return new WaitForSeconds(tiempo);
        if (portalCollider.bounds.Intersects(playerCollider.bounds))
        {
            player.position = nuevaPosisionJugador;
        }
    }
}
