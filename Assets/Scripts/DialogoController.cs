using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DialogoController : MonoBehaviour
{
    public static DialogoController Instance;
    
    [SerializeField] private Text dialogo;
    [SerializeField] private float dialogoTiempo = 3f;
    void Start()
    {
        gameObject.SetActive(false);
    }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void MostrarDialogo(string dialogo)
    {
        this.dialogo.text = dialogo;
        gameObject.SetActive(true);
        Invoke(nameof(OcultarDialogo), dialogoTiempo);
    }
    
    public void OcultarDialogo()
    {
        this.dialogo.text = null;
        gameObject.SetActive(false);
    }
    
}
