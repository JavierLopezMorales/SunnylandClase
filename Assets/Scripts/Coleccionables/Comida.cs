using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comida : Coleccionable
{
    [SerializeField] private int vidaRecuperada = 1;
    protected override void Recoger()
    {
        Datos.Instancia.ActualizarVida(vidaRecuperada);
    }
}
