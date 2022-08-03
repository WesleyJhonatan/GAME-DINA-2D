using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOMsalvar : MonoBehaviour
{
    //Som Morte
    public AudioSource Schec;
   
    private Animator Animacao;

    // Start is called before the first frame update
    void Start()
    {
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
            Animacao.SetBool("Brilhosalve", true);
        }
    }

    public void SOMC()
    {

     
        Schec.volume = 1;
    }

    public void MORTEC()
    {

        Destroy(gameObject);
    }
}
