using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReiniciaMorte : MonoBehaviour
{

    private GameObject Jogador;

    // Start is called before the first frame update
    void Start()
    {
        Jogador = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChamarIniciar()
    {
       
        Jogador.GetComponent<personagen>().Inicializar();
        Jogador.GetComponent<personagen>().SomMorte();

    }
}
