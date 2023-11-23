using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private Camera camera;
    
    BoxCollider boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }
    
private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !CameraController.Instance.IsActive(camera))
        {
            CameraController.Instance.SwitchCamera(camera);
        }
    }
}
