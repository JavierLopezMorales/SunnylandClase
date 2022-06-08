using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Introduccion : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI cargando;
    [SerializeField] private Slider barraProgreso;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CargarMenu());
    }

    // Update is called once per frame
    void Update()
    {
        cargando.SetText($"Cargando: {barraProgreso.value * 100:0}%");
    }

    private IEnumerator CargarMenu()
    {
        yield return new WaitForSeconds(3.25f);
        GameManager.Instancia.MostrarMenu();
    }
}
