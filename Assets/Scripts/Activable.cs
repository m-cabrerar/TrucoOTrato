using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Activable : MonoBehaviour
{
    [SerializeField] private PulsadorController[] pulsadores;

    [SerializeField] private Collider collider;
    [SerializeField] private MeshRenderer meshRenderer;
    
    private void Awake()
    {
        if (pulsadores.Any(p => !p.isActive()))
        {
            collider.enabled = false;
            meshRenderer.enabled = false;
        }
    }
    
    private void Update()
    {
        if (pulsadores.Any(p => !p.isActive()))
        {
            collider.enabled = false;
            meshRenderer.enabled = false;
        }
        else
        {
            collider.enabled = true;
            meshRenderer.enabled = true;
        }
    }
}
