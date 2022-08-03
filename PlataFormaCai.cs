using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlataFormaCai : MonoBehaviour
{
    //Som Plataforma
    public AudioSource PlataformaS;
    private float VolumePlataforma = 0;
    public float Velocidade5;

    //controla o jogo

    private GerenciadorJogo GJ;
    public float velocidade = 0;
    private bool pisou = false;


    public GameObject Objeto;
    public GameObject Objeto2;


    // Start is called before the first frame update
    void Start()
    {
        // Recebe a informação do GameObject

        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorJogo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        {
            Cai();

        }
    }

    void Cai()

    {
        if (pisou == true)
        {

            transform.position = new Vector3(transform.position.x, transform.position.y - velocidade, transform.position.z);

        }

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (transform.position.y < Objeto.transform.position.y + 0)
        {


            transform.position = new Vector3(transform.position.x, Objeto2.transform.position.y, transform.position.z);

            pisou = false;

            PlataformaS.volume = VolumePlataforma = 0;

        }



    }

    void OnTriggerEnter2D(Collider2D colidiu)

    {
        if (colidiu.gameObject.name == "personagem_pe")
        {
            VolumePlataforma = Velocidade5;
            PlataformaS.volume = VolumePlataforma * 4;
            pisou = true;

        }

    }
}
