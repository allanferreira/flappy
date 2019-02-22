using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diretor : MonoBehaviour
{
    public Player Player;
    Score Score;
    ControleDeDificuldade ControleDeDificuldade;
    public GameObject FundoGameOver;
    public GameObject GetReady;
    public bool GameStarted = false;
    public AudioClip GetReadySound;
    AudioSource AudioSource;
    bool ImpulcionarTrigger = false;

    private void Start()
    {
        ControleDeDificuldade = FindObjectOfType<ControleDeDificuldade>();
        AudioSource = GetComponent<AudioSource>();
        Score = FindObjectOfType<Score>();
        Player = FindObjectOfType<Player>();
    }

    public void FinalizarJogo()
    {
        Time.timeScale = 0;
        Score.Save();
        FundoGameOver.SetActive(true);
    }

    public void ReiniciarJogo()
    {
        FundoGameOver.SetActive(false);
        Time.timeScale = 1;

        Player.Reiniciar();
        Score.Reiniciar();
        DestruirObstaculos();
        ControleDeDificuldade.TempoPassado = 0;
        ImpulcionarTrigger = true;
    }

    void DestruirObstaculos()
    {
        Obstaculo[] Obstaculos = FindObjectsOfType<Obstaculo>();
        foreach(Obstaculo Obstaculo in Obstaculos)
        {
            Obstaculo.Destruir();
        }
    }

    private void Update()
    {
        if (!GameStarted && (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1")))
        {
            AudioSource.PlayOneShot(GetReadySound);
            //ImpulcionarTrigger = true;

            GameStarted = true;
            GetReady.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if(ImpulcionarTrigger)
        {
            ImpulcionarTrigger = false;
            Player.Impulcionar(false);
        }
    }

}
