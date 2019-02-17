using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDeDificuldade : MonoBehaviour
{   
    public float TempoParaDificuldadeMaxima;
    public float TempoPassado;
    public float Dificuldade { get; private set; }


    void Update()
    {
        TempoPassado += Time.deltaTime;
        Dificuldade = Mathf.Min(1, TempoPassado / TempoParaDificuldadeMaxima);
    }
}
