using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOMmunicao : MonoBehaviour
{
    //Audio
    public AudioSource Smunicao;
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
            
            Animacao.SetBool("Brilhoo", true);
        }

    }

    void DestroyMunicao()
    {
       
        //destroy o munição
        Destroy(gameObject);

    }

    void SomMunicao()
    {
        Smunicao.volume = 1;
    }
}
