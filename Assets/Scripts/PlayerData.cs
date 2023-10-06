using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    public Vector3 playerPosition;
    public Quaternion playerRotation;

    private void Awake()
    {
        if (PlayerData.Instance == null)
        {
            PlayerData.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
