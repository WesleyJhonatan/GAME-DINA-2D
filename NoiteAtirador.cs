using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiteAtirador : MonoBehaviour
{
    private Animator Animacao;
    public GameObject Bomba;
    private float posX;

    public AudioSource Satirador;
   
    //controla o jogo
    private GerenciadorJogo GJ;

    // Start is called before the first frame update
    void Start()
    {
        //Animacao recebe componente
        Animacao = GetComponent<Animator>();

        // Recebe a informação do GameObject
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorJogo>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LancarBomba(float PosPersonagem)
    {
        posX = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        GameObject MinhaBomba = Instantiate(Bomba, transform.position, Quaternion.identity);

        if (posX > transform.position.x)
        {

            MinhaBomba.GetComponent<Rigidbody2D>().velocity = new Vector2(4, 3);
            GetComponent<SpriteRenderer>().flipX = true;

        }

        else
        {

            MinhaBomba.GetComponent<Rigidbody2D>().velocity = new Vector2(-4, 3);
            GetComponent<SpriteRenderer>().flipX = false;

        }

        Destroy(MinhaBomba, 3f);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<Animator>().SetBool("Entrou", true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            GetComponent<Animator>().SetBool("Entrou", false);
        }
    }

    public void OnCollisionEnter2D(Collision2D colisao)

    {

        if (colisao.gameObject.tag == "laser")

        {
           
            Animacao.SetBool("ExplosaoAtirador", true);
            GJ.ChamaContadorAtirador();

        }

    }

    public void MataAtirador()
    {
        Satirador.volume = 0;
        Animacao.SetBool("ExplosaoAtirador", false);
        //Destroi o atirador
        Destroy(this.gameObject);

    }

    public void SomAtirador()
    {
        Satirador.volume = 1;
    }


}
