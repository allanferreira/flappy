using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public float Velocidade = 2.0f;
    public float VariacaoDeAltura = 1.5f;
    Vector3 PlayerPosition;
    bool Pontuei;
    float LarguraReal;
    Score Score;

    private void Start()
    {
        PlayerPosition = FindObjectOfType<Player>().transform.position;
        Score = FindObjectOfType<Score>();

    }

    private void Awake()
    {

        SpriteRenderer Cano = GetComponentInChildren<SpriteRenderer>();
        float Largura = Cano.size.x;
        float Escala = Cano.transform.localScale.x;
        LarguraReal = Escala * Largura;

        transform.Translate(Vector3.up * Random.Range(-VariacaoDeAltura, VariacaoDeAltura));
    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * Velocidade);

        if (!Pontuei && CentroDoObstaculo() < PlayerPosition.x)
        {
            Pontuei = true;
            Score.Adiciona();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destruir();
    }

    public void Destruir()
    {
        Destroy(this.gameObject);
    }

    float CentroDoObstaculo()
    {

        return transform.position.x + LarguraReal/2;
    }
}
