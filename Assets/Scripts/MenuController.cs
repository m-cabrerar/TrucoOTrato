using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Jugar()
    {
        InventoryController.Instance?.Reset();
        SceneManager.LoadScene((int)Escena.BOSQUE_1);
    }
    public void Salir()
    {
        Application.Quit();
    }
}
