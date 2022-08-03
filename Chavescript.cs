using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chavescript : MonoBehaviour
{
    //Som Da Moeda
    public AudioSource Schave;

    private Animator Animacao;

    //numero que ira aparecer ao pegar a chave

    public List<GameObject> numerosC;
    public List<GameObject> numerosC2;
    private int chavenumero = 0;
    private int chavenumero2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        MostrarNumeroChave();

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
            Animacao.SetBool("BrilhoChave", true);
            switch (chavenumero)
            {

                case 0:
                    numerosC[0].SetActive(true);
                    numerosC[1].SetActive(false);
                    break;


            }
        }

    }

    private void MostrarNumeroChave()
    {

        switch (chavenumero2)
        {

            case 0:
                numerosC2[0].SetActive(true);
                break;


        }

    }

    void MorrerChave()

    {
        Destroy(gameObject);
    }

    void SomChave()

    {

        Schave.volume = 1;

    }
}
