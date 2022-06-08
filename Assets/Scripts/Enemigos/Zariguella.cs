using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class Zariguella : Enemigo
{
    [SerializeField] private List<float> camino;
    [SerializeField] private float maximaVelocidad = 5.0f;

    private float posYInicial;

    protected override void Start()
    {
        posYInicial = transform.position.y;
        base.Start();
    }

    protected override IEnumerator Mover()
    {
        while (true)
        {
            foreach (var punto in camino)
            {
                if (transform.position.x != punto)
                {
                    ComprobarVoltear(punto);
                    yield return StartCoroutine(MoverADestino(punto));
                    yield return StartCoroutine(Descansar());
                }
            }
        }
    }

    private void ComprobarVoltear(float punto)
    {
        figura.flipX = transform.position.x < punto || transform.position.x == punto;
    }

    private IEnumerator MoverADestino(float destino)
    {
        Vector2 vDestino = new Vector2(destino, posYInicial);
        var velocidad = Random.Range(1f, maximaVelocidad);
        while (transform.position.x != destino)
        {
            yield return null;
            transform.position = Vector2.MoveTowards(transform.position, vDestino, maximaVelocidad * Time.deltaTime);
        }
    }

}
