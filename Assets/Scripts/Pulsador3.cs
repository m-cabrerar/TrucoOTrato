using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulsador3 : MonoBehaviour
{
    public ControlPortalLaberinto controlPortalLab;

    private void OnTriggerEnter(Collider other)
    {
        Vector3 posicionActual = transform.position;
        posicionActual.y = 0.15f;
        transform.position = posicionActual;
        controlPortalLab.setPulsador3(false);
    }
    
    private void OnTriggerExit(Collider other)
    {
        Vector3 posicionActual = transform.position;
        posicionActual.y = 0.25f;
        transform.position = posicionActual;
        controlPortalLab.setPulsador3(true);
    }
}
