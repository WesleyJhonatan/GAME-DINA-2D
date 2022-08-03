using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class inimigo1 : MonoBehaviour
{

    private SpriteRenderer ImagemCogumelo;
    private Animator Animacao;
    public float velocidade = 0.1f;
    public float distInicial = 0;
    public float distFinal = 0f;

    //Audio Morrendo
    public AudioSource Sinimigo;

    //Audio Andando
    public AudioSource SAndarInimigo;

    //controla o jogo
    private GerenciadorJogo GJ;


    void Start()
    {
        //Animacao recebe componente

        Animacao = GetComponent<Animator>();

        // Recebe a informação do GameObject
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorJogo>();

        ImagemCogumelo = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame

    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        {
            andar();
        }
    }

    void andar()
    {
        transform.position = new Vector3(transform.position.x + velocidade, transform.position.y, transform.position.z);
        // andar para tras
        if (transform.position.x > distFinal)
        {
            velocidade = velocidade * -1;
            ImagemCogumelo.flipX = true;
        }
        // andar para frente
        if (transform.position.x < distInicial)
        {
            velocidade = velocidade * -1;
            ImagemCogumelo.flipX = false;
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "laser")

        {
           
            Animacao.SetBool("Explosao", true);
            GJ.ChamaContadorCQ();

        }

    }

    void DestroyInimigo()
    {
        
        //destroy o inimigo
        Destroy(this.gameObject);

    }

    void SomInimigo()
    {
        Sinimigo.volume = 1;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SAndarInimigo.volume = 0.495f;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            SAndarInimigo.volume = 0;
        }
    }
}

