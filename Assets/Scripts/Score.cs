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
    public GameObject NewRecord;

    public Image MedalUI;
    public Sprite GoldMedal;
    public Sprite SilverMedal;
    public Sprite BronzeMedal;

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
        NewRecord.SetActive(false);
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
            NewRecord.SetActive(true);
            PlayerPrefs.SetInt("record", Pontos);
        }

        ChooseMedal();
        RecordUI.text = PlayerPrefs.GetInt("record").ToString();
        FinalScoreUI.text = Pontos.ToString();
    }

    void ChooseMedal()
    {
        int Record = PlayerPrefs.GetInt("record");
        if(Pontos >= Record)
        {
            MedalUI.sprite = GoldMedal;
        } 
        else if(Pontos >= Record/2)
        {
            MedalUI.sprite = SilverMedal;
        }
        else
        {
            MedalUI.sprite = BronzeMedal;
        }

    }

}
