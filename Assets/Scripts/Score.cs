using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int Pontos = 0;
    public Text ScoreUI;
    public Text FinalScoreUI;
    public Text RecordUI;
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
        ScoreUI.enabled = true;
    }

    void ScoreUIRender()
    {
        ScoreUI.text = Pontos.ToString();
    }

    public void Save()
    {
        ScoreUI.enabled = false;

        int Record = PlayerPrefs.GetInt("record");

        if(Pontos > Record)
        {
            PlayerPrefs.SetInt("record", Pontos);
        }

        RecordUI.text = PlayerPrefs.GetInt("record").ToString();
        FinalScoreUI.text = Pontos.ToString();
    }

}
