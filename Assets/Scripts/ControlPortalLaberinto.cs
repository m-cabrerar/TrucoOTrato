using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPortalLaberinto : MonoBehaviour
{
    public Transform portalLab;

    public float velocMov = 1.0f;

    public bool pulsador3Activado = true;
    private Vector3 posicionOriginal;
    private Vector3 nuevaPosicion = new Vector3(8.5f, -1f, -17.5f);
    
    float tiempoEspera = 6.0f;
    float tiempoTranscurrido = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        posicionOriginal = portalLab.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (pulsador3Activado)
        {
            if (tiempoTranscurrido < tiempoEspera)
            {
                tiempoTranscurrido += Time.deltaTime;
            }
            else
            {
                portalLab.position =
                    Vector3.Lerp(portalLab.position, nuevaPosicion, velocMov * Time.deltaTime);
            }
            
        }
        else
        {
            tiempoTranscurrido = 0.0f;
            portalLab.position =
                Vector3.Lerp(portalLab.position, posicionOriginal, velocMov * Time.deltaTime);
        }
    }

    public void setPulsador3(bool activado)
    {
        pulsador3Activado = activado;
    }
}
