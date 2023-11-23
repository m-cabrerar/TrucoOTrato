using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsadorController : MonoBehaviour
{
    private bool active;
    private float initialHeight;
    
    private void Awake()
    {
        initialHeight = transform.position.y;
    }
    
    private void OnTriggerStay(Collider other)
    {
        transform.position = new Vector3(transform.position.x, initialHeight - 0.1f, transform.position.z);
        active = true;
    }
    
    private void OnTriggerExit(Collider other)
    {
        transform.position = new Vector3(transform.position.x, initialHeight, transform.position.z);
        active = false;
    }

    public bool isActive()
    {
        return active;
    }
}
