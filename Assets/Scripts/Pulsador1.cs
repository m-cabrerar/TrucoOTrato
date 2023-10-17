using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pulsador1 : MonoBehaviour
{
    public MovimientoPortalPulsadores controlMov;
    public float distAMoverY = 0.125f;
    private void OnTriggerEnter(Collider other)
    {
        Vector3 posicionActual = transform.position;
        posicionActual.y -= distAMoverY;
        transform.position = posicionActual;
        controlMov.setPulsador1(true);
    }
    
    private void OnTriggerExit(Collider other)
    {
        Vector3 posicionActual = transform.position;
        posicionActual.y += distAMoverY;
        transform.position = posicionActual;
        controlMov.setPulsador1(false);
    }
}
