using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlataformaDireitaEsquerda : MonoBehaviour
{
    //Som Plataforma Direita Esquerda
    public AudioSource Spde;

    //controla o jogo

    public Rigidbody2D Corpo;
    public float posInicial;
    public float posFinal;
    public float velocidade;

    
    // Start is called before the first frame update
    void Start()
    {
        Corpo = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < posInicial)
        {
            velocidade = 4;
        }

        if (transform.position.x > posFinal)
        {
            velocidade = -4;
        }

        Corpo.velocity = new Vector2(velocidade, 0);
    }

    void OnCollisionStay2D(Collision2D colisao)
    {
        if (colisao.gameObject.tag == "Player")

        {
           
            Spde.volume = 1;

        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Spde.volume = 0;
        }

    }

    public float PlataformaMove()
    {

        return velocidade;
    }

   
}
