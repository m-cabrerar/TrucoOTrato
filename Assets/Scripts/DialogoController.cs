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
    private HashSet<string> dialogosMostrados = new() {};
    public const string MOSTRAR_SIEMPRE = "";
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
    public void MostrarDialogo(Dialogo dialogo, string id)
    {
        MostrarDialogo(dialogo.dialogo, id, dialogo.mostrarUnaVez);
    }
    public void MostrarDialogo(string dialogo, string id = "", bool mostrarUnaVez = false)
    {
        if (dialogo == null || dialogo.Trim().Equals("")) return;
        if (mostrarUnaVez && Mostrado(id)) return;
        dialogosMostrados.Add(id);
        this.dialogo.text = dialogo;
        gameObject.SetActive(true);
        Invoke(nameof(OcultarDialogo), dialogoTiempo);
    }
    
    public bool Mostrado(string id)
    {
        return id.Equals(MOSTRAR_SIEMPRE) || dialogosMostrados.Contains(id);
    }
    
    public void OcultarDialogo()
    {
        this.dialogo.text = null;
        gameObject.SetActive(false);
    }
    
}
