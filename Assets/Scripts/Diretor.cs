using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diretor : MonoBehaviour
{
    public Player Player;
    Score Score;
    public GameObject FundoGameOver;

    private void Start()
    {
        Score = FindObjectOfType<Score>();
        Player = FindObjectOfType<Player>();
    }

    public void FinalizarJogo()
    {
        Time.timeScale = 0;
        FundoGameOver.SetActive(true);
    }

    public void ReiniciarJogo()
    {
        FundoGameOver.SetActive(false);
        Time.timeScale = 1;

        Player.Reiniciar();
        Score.Reiniciar();
        DestruirObstaculos();
    }

    void DestruirObstaculos()
    {
        Obstaculo[] Obstaculos = FindObjectsOfType<Obstaculo>();
        foreach(Obstaculo Obstaculo in Obstaculos)
        {
            Obstaculo.Destruir();
        }
    }
}
