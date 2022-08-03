using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOMpresi : MonoBehaviour
{
    //Som PRESIDENTE
    public AudioSource Spresidente;
    private float VolumePresidente = 0;
    public float Velocidade5;
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
            Animacao.SetBool("BrilhoPresi", true);
        }
    }

    public void SomPresidentePara()
    {
        VolumePresidente = Velocidade5;
        Spresidente.volume = VolumePresidente * 4;
        //Spresidente.volume = Velocidade5 = 0;
    }

    public void MataPresidente()
    {
        Destroy(gameObject);
    }
}
