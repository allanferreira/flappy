using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeObstaculos : MonoBehaviour
{
    public float TempoParaGerar = 2;
    float Cronometro;
    public GameObject Obstaculo;

    private void Awake()
    {
        Cronometro = TempoParaGerar;
    
    }

    void Update()
    {
        Cronometro -= Time.deltaTime;
        if(Cronometro <= 0)
        {
            Instantiate(Obstaculo, transform.position, Quaternion.identity);
            Cronometro = TempoParaGerar;
        }
    }
}
