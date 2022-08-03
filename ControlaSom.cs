using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;



public class ControlaSom : MonoBehaviour
{
    public AudioMixer MeuAudio;
    public bool estadoSom = true;
    public Image ImgSom;
    public Sprite ImgLigado;
    public Sprite ImgDesligado;

    public bool estadoSom2 = true;
    public Image ImgSom2;
    public Sprite ImgLigado2;
    public Sprite ImgDesligado2;

    // Start is called before the first frame update
    void Start()
    {
        Ligar();
        Ligar2();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void AlterarSom()
    {
        if(estadoSom == true)
        {
            Desligar();
           
        }

        else
        {
            Ligar();
        }
    }

    public void AlterarSom2()
    {
        if (estadoSom2 == true)
        {
            Desligar2();

        }

        else
        {
            Ligar2();
        }
    }

    //Musica
    public void Desligar()
    {
        estadoSom = false;
        MeuAudio.SetFloat("BG", -80f);
        ImgSom.sprite = ImgDesligado;
    }

    public void Ligar()
    {
        estadoSom = true;
        MeuAudio.SetFloat("BG", 0f);
        ImgSom.sprite = ImgLigado;
    }


    //Som
    public void Desligar2()
    {
        estadoSom2 = false;
        MeuAudio.SetFloat("Fx", -80f);
        ImgSom2.sprite = ImgDesligado2;
    }

    public void Ligar2()
    {
        estadoSom2 = true;
        MeuAudio.SetFloat("Fx", 0f);
        ImgSom2.sprite = ImgLigado2;
    }
}
