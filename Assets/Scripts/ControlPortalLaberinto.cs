using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ControlPortalLaberinto : MonoBehaviour
{
    [SerializeField] private Transform portalLab;
    [SerializeField] private float velocMov = 1.0f;
    [SerializeField] private float tiempoEspera = 6.0f;
    [SerializeField] private PulsadorController[] pulsadores;

    private Vector3 posicionOriginal;
    private Vector3 nuevaPosicion;
    private float tiempoTranscurrido = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        posicionOriginal = portalLab.position;
        nuevaPosicion = new Vector3(portalLab.position.x, portalLab.position.y + 2f, portalLab.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (pulsadores.Length == 0 || pulsadores.All(p => p.isActive()))
        {
            tiempoTranscurrido = 0.0f;
            portalLab.position = Vector3.Lerp(portalLab.position, nuevaPosicion, velocMov * Time.deltaTime);
        }
        else
        {
            if (tiempoTranscurrido < tiempoEspera)
                tiempoTranscurrido += Time.deltaTime;
            else
                portalLab.position = Vector3.Lerp(portalLab.position, posicionOriginal, velocMov * Time.deltaTime);
        }
    }
}
