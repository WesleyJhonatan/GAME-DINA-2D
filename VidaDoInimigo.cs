using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;







public class VidaDoInimigo : MonoBehaviour
{
    private Animator Animacao;

    private SpriteRenderer ImagemCogumelo;

    public float velocidade = 0.1f;
    public float distInicial = -12.18f;
    public float distFinal = 6.81f;
    public int vidaAtual = 7;
    private GerenciadorJogo GJ;

    //numeros que ira aparecer quando ativar a tela conquista
    public List<GameObject> numeros;

    public List<GameObject> numeros2;

    private int contaboss = 0;

    //Som Da Explosao
    public AudioSource SExplosao;

    //Audio Andando
    public AudioSource SAndarBoss;

    //controla o jogo
    void Start()
    {
        //Animacao recebe componente
        Animacao = GetComponent<Animator>();

        // Recebe a informação do GameObject
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorJogo>();

        ImagemCogumelo = GetComponent<SpriteRenderer>();

        MostrarNumeros();



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




    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.tag == "laser")
        {
          
            //destroi bala
            Destroy(colisao.gameObject);


            vidaAtual -= 1;

            if (vidaAtual <= 0)
            {
                Animacao.SetBool("ExplosaoAzul", true);
                
                //numero 1 aparecera na tela de conquista
                switch (vidaAtual)
                {

                    case 0:
                        numeros[0].SetActive(true);
                        numeros[1].SetActive(false);
                        break;
                   

                }
            }
        }
    }

    // numero 0 aparecera na telade conquista


    private void MostrarNumeros()
    {
         
        switch (contaboss)
        {
           
            case 0:
                numeros2[0].SetActive(true);
                break;
           

        }

    }

    void ComecaSom()
    {

        SExplosao.volume = 1;

    }

    void DestroyBoss()
    {
        SExplosao.volume = 0;
        //destroy o Boss
        Destroy(this.gameObject);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SAndarBoss.volume = 0.495f;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            SAndarBoss.volume = 0;
        }
    }

}
