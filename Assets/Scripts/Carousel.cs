using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carousel : MonoBehaviour
{
    Vector3 PosicaoInicial;
    public ShareVariableFloat Velocidade;
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
        print(Velocidade.value);
        float Deslocamento = Mathf.Repeat(Velocidade.value * Time.time, LarguraReal);

        transform.position = PosicaoInicial + (Vector3.left * Deslocamento);

    }
}
