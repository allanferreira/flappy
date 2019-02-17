using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeObstaculos : MonoBehaviour
{
    public float TempoParaGerarFacil   = 10;
    public float TempoParaGerarDificil = 0.5f;
    float Cronometro;
    public GameObject Obstaculo;
    Diretor Diretor;
    ControleDeDificuldade ControleDeDificuldade;

    private void Awake()
    {
        Cronometro = TempoParaGerarFacil;
    
    }

    private void Start()
    {
        Diretor = FindObjectOfType<Diretor>();
        ControleDeDificuldade = FindObjectOfType<ControleDeDificuldade>();
    }

    void Update()
    {

        if (!Diretor.GameStarted)
            return ;

        Cronometro -= Time.deltaTime;
        if(Cronometro <= 0)
        {
            Instantiate(Obstaculo, transform.position, Quaternion.identity);
            Cronometro = Mathf.Lerp(
                            TempoParaGerarFacil, 
                            TempoParaGerarDificil, 
                            ControleDeDificuldade.Dificuldade
                         );
        }
    }
}
