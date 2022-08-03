using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiteVoador : MonoBehaviour
{
    //controla o jogo
    private GerenciadorJogo GJ;
    private Animator Animacao;
    public float disInicial;
    public float disFinal;
    float Velocidade = 0.05f;
    public bool seguindo = false;

    //Audio
    public AudioSource SPassaro;
    private float VolumePassaro = 0;
    public float Velocidade2;


    void Start()
    {
        // Recebe a informação do GameObject
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorJogo>();

        //Animacao recebe componente
        Animacao = GetComponent<Animator>();
    }

   
    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        {
            //Voar()
            if (seguindo == false)
            {
                Voar();
            }
        }
       

    }

    void Voar()
    {

        if (transform.position.x < disInicial)
        {
            Velocidade = 0.05f;
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (transform.position.x > disFinal)
        {

            Velocidade = -0.05f;
            GetComponent<SpriteRenderer>().flipX = true;

        }

        transform.position = new Vector3(transform.position.x + Velocidade, transform.position.y, transform.position.z);
    }

   
    void OnTriggerStay2D(Collider2D contato)
    {
        if (contato.gameObject.tag == "Player")
        {
            Animacao.SetBool("Segui", true);
            seguindo = true;
            Vector3 posPlayer = contato.gameObject.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, posPlayer, 0.05f);
            
        }
    }

    void OnTriggerExit2D(Collider2D contato)
    {
       
        Animacao.SetBool("Segui", false);
        seguindo = false;
    }

    public void OnCollisionEnter2D(Collision2D colisao)

    {

        if (colisao.gameObject.tag == "laser")

        {
            Animacao.SetBool("ExplosaoVoador", true);
            GJ.ChamaContadorPassaro();
            //destroi a bala
            Destroy(colisao.gameObject);
        }

    }

    public void MortePasaro()
    {
        //destroi Passaro
        Destroy(this.gameObject);
    }

    void SomPassaro()
    {
        VolumePassaro = Velocidade2;
        SPassaro.volume = VolumePassaro * 4;
    }
}
