using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPortalPulsadores : MonoBehaviour
{
    public Transform portalAMover;

    public float velocidadMov = 3.0f;

    private bool pulsador1Activado = false;
    private bool pulsador2Activado = false;

    private Vector3 posicionOriginal;
    private Vector3 nuevaPosicion = new Vector3(0f, 1f, -8f);
    // Start is called before the first frame update
    void Start()
    {
        posicionOriginal = portalAMover.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (pulsador1Activado && pulsador2Activado)
        {
            portalAMover.position =
                Vector3.Lerp(portalAMover.position, nuevaPosicion, velocidadMov);
        }
        else
        {
            portalAMover.position =
                Vector3.Lerp(portalAMover.position, posicionOriginal, velocidadMov);
        }
    }

    public void setPulsador1(bool activado)
    {
        pulsador1Activado = activado;
    }
    
    public void setPulsador2(bool activado)
    {
        pulsador2Activado = activado;
    }
}
