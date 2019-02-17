using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int Pontos = 0;
    public Text ScoreUI;
    AudioSource HitSound;

    private void Awake()
    {
        HitSound = GetComponent<AudioSource>();
    }

    public void Adiciona()
    {
        Pontos++;
        ScoreUIRender();
        HitSound.Play();
    }

    public void Reiniciar()
    {
        Pontos = 0;
        ScoreUIRender();
    }

    void ScoreUIRender()
    {
        ScoreUI.text = Pontos.ToString();
    }
}
