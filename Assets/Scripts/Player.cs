using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D Fisica;
    public float Forca = 7.5f;

    Vector3 StartPosition;
    AudioSource Audio;
    public AudioClip WingSound;
    public AudioClip HitSound;
    Diretor Diretor;
    bool ImpulcionarTrigger = false;


    void Awake()
    {
        StartPosition = transform.position;
        Fisica = GetComponent<Rigidbody2D>();
        Audio = GetComponent<AudioSource>();
        Fisica.simulated = false;
    }

    private void Start()
    {
        Diretor = FindObjectOfType<Diretor>();
    }

    void Update()
    {

        if (!Diretor.GameStarted)
        {
            return;
        }

        Fisica.simulated = true;

        if (Time.timeScale > 0 && Input.GetButtonDown("Jump"))
        {
            ImpulcionarTrigger = true;
        }

    }

    void FixedUpdate()
    {
        if(ImpulcionarTrigger)
        {
            ImpulcionarTrigger = false;
            Impulcionar();
        }

    }

    public void Impulcionar(bool sound = true)
    {
        Fisica.velocity = Vector2.zero;
        Fisica.AddForce(Vector2.up * Forca, ForceMode2D.Impulse);

        if(sound)
            Audio.PlayOneShot(WingSound);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Audio.PlayOneShot(HitSound);
        Diretor.FinalizarJogo();
        Fisica.simulated = false;
    }

    public void Reiniciar()
    {
        transform.position = StartPosition;
        Fisica.simulated = true;
    }

}
