using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Moeda : MonoBehaviour
{
    //Som Da Moeda
    public AudioSource Smoeda;
    private Animator Animacao;
    
    // Start is called before the first frame update
    void Start()
    {
        //Animacao recebe componente

        Animacao = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D gatilho)

    {

        if (gatilho.gameObject.tag == "Player")
        {
           
            Animacao.SetBool("MoedaMorte", true);

        }
    }

    void MorrerMoeda()

    {

        Destroy(this.gameObject);

    }

    void SomMoeda()

    {
        Smoeda.volume = 1;

    }
}
