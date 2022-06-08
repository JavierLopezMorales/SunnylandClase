using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton & DDOL
    public static GameManager Instancia { get; private set; }

    private void Awake()
    {
        if (Instancia != null)
        {
            Destroy(gameObject);
        }
        Instancia = this;
        DontDestroyOnLoad(this);
    }
    #endregion
    public bool GameOver { get; private set; }
    public int NivelActual { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Datos.Instancia.OnTiempoActualizado += ActualizarTiempo;
        Datos.Instancia.OnVidaActualizada += ActualizarVidas;
        Datos.Instancia.OnGemasActualizado += ActualizarGemas;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActualizarTiempo(int tiempo)
    {
        if (tiempo <= 0)
        {
            MostrarMenu();
        }
    }

    public void ActualizarVidas(int vidas)
    {
        if(vidas <= 0)
        {
            MostrarResultados(true);
        }
    }

    public void ActualizarGemas(int gemas)
    {
        if (gemas <= 0 && NivelActual == 3)
        {
            MostrarResultados(false);
        }
        if (gemas <= 0 && NivelActual == 2)
        {
            MostrarSiguienteNivel();
        }

    }

    public void MostrarSiguienteNivel()
    {
        NivelActual++;
        SceneManager.LoadScene(3);
        Datos.Instancia.EstablecerValores();
    }

    public void MostrarMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Jugar() 
    {
        NivelActual = 2;
        SceneManager.LoadScene(2);
        Datos.Instancia.ReiniciarValores();
    }

    public void ReiniciarNivel()
    {
        SceneManager.LoadScene(NivelActual);
        Datos.Instancia.EstablecerValores();
    }

    public void Salir()
    {
        Application.Quit();
    }

    private void MostrarResultados(bool gameOver)
    {
        GameOver = gameOver;
        SceneManager.LoadScene("Resultados");
        //Audio.Instancia.PlayIntroduccion();
    }
}
