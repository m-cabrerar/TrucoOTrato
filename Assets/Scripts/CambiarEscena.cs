using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    private bool cambioDeEscenaRealizado = false;

    /*private void Start()
    {
        cambioDeEscenaRealizado = true;
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (!cambioDeEscenaRealizado)
        {
            switch (other.tag)
            {
                case "Trigger1To2":

                    PlayerData.Instance.playerPosition = new Vector3(-9f, 1f, 0f);
                    PlayerData.Instance.playerRotation = Quaternion.Euler(0f, 90f, 0f);
                    SceneManager.LoadScene(2);
                    cambioDeEscenaRealizado = true;
                    break;
                case "Trigger2To1":

                    PlayerData.Instance.playerPosition = new Vector3(0f, 1f, 9f);
                    PlayerData.Instance.playerRotation = Quaternion.Euler(0f, 180f, 0f);
                    SceneManager.LoadScene(1);
                    cambioDeEscenaRealizado = true;
                    break;
                default:
                    break;
            }
        }
    }
}