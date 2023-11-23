using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Dialogo
{
    [TextArea] public string dialogo;
    public float duracion;
    public bool mostrarUnaVez;
}
