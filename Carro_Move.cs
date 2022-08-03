using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Carro_Move : MonoBehaviour

{
    public float velocidade = 0;
    public GameObject Jogador;
    // Start is called before the first frame update


    //controla o jogo

    private GerenciadorJogo GJ;

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
            CarroVelocidade();
        }

    }

    void CarroVelocidade()
    {

        transform.position = new Vector3(transform.position.x + velocidade, transform.position.y, transform.position.z);

        if (transform.position.x < Jogador.transform.position.x - 16)
        {
            float posY = UnityEngine.Random.Range(-3.88f, 1.93f);

            transform.position = new Vector3(Jogador.transform.position.x + 16, posY, transform.position.z);

        }


        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (transform.position.y < Jogador.transform.position.y + 0)
        {
            float posY = UnityEngine.Random.Range(-3.88f, 1.93f);

            transform.position = new Vector3(transform.position.x, Jogador.transform.position.y + 0 + posY, transform.position.z);

        }
    }

}
