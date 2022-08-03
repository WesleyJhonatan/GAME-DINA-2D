using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ControleBala : MonoBehaviour
{
    private float velocidade_bala = 0;

    //controla o jogo

    private GerenciadorJogo GJ;

    //Audio
    public AudioSource Sbala;

    void Start()
    {
       

        // Recebe a informação do GameObject
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorJogo>();


    }


    void Update()
    {
        if (GJ.EstadoDoJogo() == true)

        {
            MoverBala();
        }


    }

    void MoverBala()

    {
        //movimentação

        transform.position = new Vector3(transform.position.x + velocidade_bala, transform.position.y, transform.position.z);

    }

    // direção da bala

    public void DirecaoBala(float direcao)

    {
       
        Sbala.volume = 1;

        velocidade_bala = direcao;
    }


    public void OnCollisionEnter2D(Collision2D colisao)

    {

    if (colisao.gameObject.tag == "inimigo")

    {

            //Destoi bala
            Destroy(this.gameObject);

    }

    }

   
}



