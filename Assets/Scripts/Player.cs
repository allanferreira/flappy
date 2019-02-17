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


    void Awake()
    {
        StartPosition = transform.position;
        Fisica = GetComponent<Rigidbody2D>();
        Audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        Diretor = FindObjectOfType<Diretor>();
    }

    void Update()
    {

        if (Input.GetButtonDown("Jump"))
        {
            Impulcionar();
        }

    }

    void Impulcionar()
    {
        Fisica.velocity = Vector2.zero;
        Fisica.AddForce(Vector2.up * Forca, ForceMode2D.Impulse);
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
