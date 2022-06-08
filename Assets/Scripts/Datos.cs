using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public delegate void ManejadorTiempoActualizado(int tiempo);
public delegate void ManejadorVidaActualizado(int vidas);
public delegate void ManejadorPuntosActualizado(int puntos);
public delegate void ManejadorGemasActualizado(int gemas);

public class Datos : MonoBehaviour
{

    [SerializeField] private int vidasIniciales = 3;
    [SerializeField] private int tiempoNivel = 300;
    [SerializeField] private int gemasIniciales = 5;


    private int puntos;
    private int vidas;
    private int gemas;
    private float tiempoInicio;
    private int tiempoRestante;

    public event ManejadorTiempoActualizado OnTiempoActualizado;
    public event ManejadorVidaActualizado OnVidaActualizada;
    public event ManejadorPuntosActualizado OnPuntosActualizado;
    public event ManejadorGemasActualizado OnGemasActualizado;

    public static Datos Instancia { get; private set; }

    private void Awake()
    {
        if (Instancia != null)
        {
            Destroy(gameObject);
        }
        Instancia = this;
    }

    private void Start()
    {
        ReiniciarValores();
    }

    private void Update()
    {
        ComprobarTiempo();
    }

    public void ReiniciarValores()
    {
        EstablecerTiempoInicio();
        vidas = vidasIniciales;
        OnVidaActualizada?.Invoke(vidas);
        puntos = 0;
        OnPuntosActualizado?.Invoke(puntos);
        SetGemasIniciales();
    }

    public void EstablecerTiempoInicio()
    {
        tiempoInicio = Time.time;
        ActualizarTiempoRestante();
    }

    public void SetGemasIniciales()
    {
        gemas = gemasIniciales;
        OnGemasActualizado?.Invoke(gemas);
    }

    private void ActualizarTiempoRestante()
    {
        var tiempoTranscurrido = Time.time - tiempoInicio;
        tiempoRestante = tiempoNivel - (int)tiempoTranscurrido;
        OnTiempoActualizado?.Invoke(tiempoRestante);
    }

    public void EstablecerValores()
    {
        EstablecerTiempoInicio();
        OnVidaActualizada?.Invoke(vidas);
        OnPuntosActualizado?.Invoke(puntos);
        SetGemasIniciales();
    }

    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;
        Debug.Log($"Puntos: {puntos}");
        //UIManager.Instancia.ActualizarPuntos(puntos);
        OnPuntosActualizado?.Invoke(puntos);
    }



    public void ActualizarVida(int cantidad)
    {
        if (cantidad < 0)
        {
            vidas--;
            Debug.Log($"Vidas: {vidas}");
            //UIManager.Instancia.ActualizarVidas(vidas);
            if (vidas <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            vidas = vidas + cantidad;
            Debug.Log($"Vidas: {vidas}");
            //UIManager.Instancia.ActualizarVidas(vidas);
        }
        OnVidaActualizada?.Invoke(vidas);
    }

    public void RecogerGema()
    {
        gemas--;
        OnGemasActualizado?.Invoke(gemas);
    }

    private void ComprobarTiempo()
    {
        var tiempo = Time.time - tiempoInicio;
        var tiempoRestante = tiempoNivel - (int)tiempo;
        //UIManager.Instancia.ActualizarTiempo(tiempoRestante);
        OnTiempoActualizado?.Invoke(tiempoRestante);
        if (tiempo >= tiempoNivel)
        {
            Debug.Log("Has perdido, se ha acabado el tiempo!!!!!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


    public int GetPuntos()
    {
        return puntos;
    }

    public int GetRecord()
    {
        var record = PlayerPrefs.GetInt("Puntos", 0);
        if (puntos > record)
        {
            PlayerPrefs.SetInt("Puntos", puntos);
        }
        return record;
    }
}
