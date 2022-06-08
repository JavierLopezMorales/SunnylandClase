using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    [SerializeField] private Animator boton;
    [SerializeField] private Animator boton1;
    [SerializeField] private Animator boton2;
    [SerializeField] private Animator creditos;
    [SerializeField] private Animator nivel1;
    [SerializeField] private Animator nivel2;

    // Start is called before the first frame update
    void Start()
    {
        boton.SetBool("estaOculto", false);
        boton1.SetBool("estaOculto", false);
        boton2.SetBool("estaOculto", false);
    }

    public void Pulsado()
    {
        if(boton.GetBool("estaOculto") == false)
        {
            boton.SetBool("estaOculto", true);
            boton1.SetBool("estaOculto", true);
            boton2.SetBool("estaOculto", true);
        }
        else
        {
            boton.SetBool("estaOculto", false);
            boton1.SetBool("estaOculto", false);
            boton2.SetBool("estaOculto", false);
        
        }
    }

    public void CreditosPulsado()
    {
        if (creditos.GetBool("Entrada") == true)
        {
            creditos.SetBool("Entrada", false);
            boton.SetBool("estaOculto", true);
            boton1.SetBool("estaOculto", true);
            boton2.SetBool("estaOculto", true);
        }
        else
        {
            creditos.SetBool("Entrada", true);
            boton.SetBool("estaOculto", false);
            boton1.SetBool("estaOculto", false);
            boton2.SetBool("estaOculto", false);

        }
    }
    
    public void JugarPulsado()
    {
        GameManager.Instancia.Jugar();
    }

    public void SalirPulsado()
    {
        
        GameManager.Instancia.Salir();
    }

}
