using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;

    [SerializeField] private Camera activeCamera;
    
    private void Awake()
    {
        Instance = this;
    }
    
    public void SwitchCamera(Camera camera)
    {
        if (activeCamera != null)
        {
            // diable gameobject
            activeCamera.tag = "Untagged";
            activeCamera.enabled = false;
        }
        activeCamera = camera;
        //activeCamera.Priority = 10;
        activeCamera.enabled = true;
        activeCamera.tag = "MainCamera";
    }
    
    public bool IsActive(Camera camera)
    {
        return activeCamera == camera;
    }
}
