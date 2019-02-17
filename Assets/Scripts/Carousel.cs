using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carousel : MonoBehaviour
{
    Vector3 PosicaoInicial;
    public float Velocidade;
    float LarguraReal;

    private void Awake()
    {
        PosicaoInicial = transform.position;
        float Largura = GetComponent<SpriteRenderer>().size.x;

        float Escala = transform.localScale.x;
        LarguraReal = Largura * Escala;
    }

    void Update()
    {
        float Deslocamento = Mathf.Repeat(Velocidade * Time.time, LarguraReal);

        transform.position = PosicaoInicial + (Vector3.left * Deslocamento);

    }
}
