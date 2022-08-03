using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Plataforma_SobeDesce : MonoBehaviour
{ //controla o jogo

    private GerenciadorJogo GJ;
    public float distInicial = -0.5f;
    public float distFinal = 2f;
    public float velocidade = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        //recebe a informação do gameobject
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorJogo>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GJ.EstadoDoJogo() == true)
        {
            SobeDesce();
        }
    }

   void SobeDesce()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + velocidade, transform.position.z);
        
        if (transform.position.y > distFinal)
        {
            velocidade = velocidade * -1;
        }

        if(transform.position.y < distInicial)
        {
            velocidade = velocidade * -1;
        }

    }
}
