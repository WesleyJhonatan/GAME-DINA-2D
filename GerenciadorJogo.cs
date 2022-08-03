using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GerenciadorJogo : MonoBehaviour
{
    //numeros que ira aparecer quando matar o inimigo
    private int contadorX = 0;
    private int contadorZ = 0;
    public List<GameObject> numerosIA;
    public List<GameObject> numerosIB;
    public List<GameObject> numerosIC;
    public List<GameObject> numerosID;
    public List<GameObject> numerosIE;
    public List<GameObject> numerosIF;
    public List<GameObject> numerosIG;
    public List<GameObject> numerosIH;
    public List<GameObject> numerosII;
    public List<GameObject> numerosIJ;
    public List<GameObject> numerosIK;

    public List<GameObject> numerosIV0;
    public List<GameObject> numerosIV1;
    public List<GameObject> numerosIV2;
    public List<GameObject> numerosIV3;
    private int contadorAT = 0;
    private int zeroIV = 0;

    public List<GameObject> numerosIP0;
    public List<GameObject> numerosIP1;
    public List<GameObject> numerosIP2;
    public List<GameObject> numerosIP3;
    private int contadorPV = 0;
    private int zeroPassaro = 0;


    // verifica se o jogo esta ligado ou não

    public bool GameLigado = false;

    // Chama tela de game oveer
    public GameObject TelaGameOver;

    public GameObject TelaPause;

    //chama tela de ganhador

    public GameObject TelaGanhador;

    //Chama tela Logo 

    public GameObject TelaLogo;

    //Chama tela Empresa

    public GameObject TelaEmpresa;

    // tira o butao da tela de conquistas
    public List<GameObject> botao1;
    private int Contador = 1;
    private int Contador2 = 0;

    //tira o butao da tela de musica
    public List<GameObject> botao2;
    private int Contador3 = 0;


    //Som da Fase
    public AudioSource SJogo;

    //Som da Fase
    public AudioSource SFase;

    //Som GameOver
    public AudioSource SGameOver;

    //Som Pronto Vai
    public AudioSource SPronto;

    //Som Parabens
    public AudioSource SParabens;

    //Som Game over
    public AudioSource SPerdeu;
   

   
    void Start()
    {
        SJogo.volume = 1;

        //Pausa o Script

        GameLigado = false;

        //  Pausa fisica do Jogo

        Time.timeScale = 0;

        MostrarNumerosInimigo();
        Contador0();
        MostrarNumeroPassaro();

    }


    void Update()
    {

    }

    public bool EstadoDoJogo()
    {

        return GameLigado;

    }

    public void LigarJogo()

    {

        SJogo.volume = 0;
        SFase.volume = 0.277f;
        GameLigado = true;
        Time.timeScale = 1;

    }

    public void PersonagemMorreu()

    {
        SPerdeu.volume = 1;
        SFase.volume = 0;
        SGameOver.volume = 0.169f;
        // Tela de Game Over
        TelaGameOver.SetActive(true);
        GameLigado = false;
        Time.timeScale = 0;
    }

    //Reiniciar do Jogo

    public void Reiniciar()

    {

        
        SGameOver.volume = 0;
        SceneManager.LoadScene(0);

    }

    //Pausa o jogo

    public void PausarJogo()

    {


        SJogo.volume = 1;
        SFase.volume = 0;

       
        GameLigado = false;
        Time.timeScale = 0;
        TelaPause.SetActive(true);

      

    }

    public void TiraPausaJogo()

    {

        SJogo.volume = 0;
        SFase.volume = 0.277f;

       
        GameLigado = true;
        Time.timeScale = 1;
        TelaPause.SetActive(false);

    }

    public void PersonagemGanhou()
    {
        SJogo.volume = 1;
        SParabens.volume = 1;
        SFase.volume = 0;

        TelaGanhador.SetActive(true);
        GameLigado = false;
        Time.timeScale = 0;

    }

    public void BTempresa()
    {

        SceneManager.LoadScene(0);
        GameLigado = false;
        Time.timeScale = 0;
        TelaEmpresa.SetActive(true);
    }


    //Numeros que ira aparecer quando eu for matando Robo atirador de bonba
    public void ChamaContadorAtirador()
    {

        contadorAT++;
        switch (contadorAT)
        {

            case 1:
                numerosIV1[0].SetActive(true);
                numerosIV1[1].SetActive(false);
                break;

        }

        switch (contadorAT)
        {

            case 2:
                numerosIV2[0].SetActive(true);
                numerosIV2[1].SetActive(false);
                break;

        }

        switch (contadorAT)
        {

            case 3:
                numerosIV3[0].SetActive(true);
                numerosIV3[1].SetActive(false);
                break;

        }
    }

    //Numero 0 que ira aparecer do Robo no inicio
    public void Contador0()
    {

        switch (zeroIV)
        {

            case 0:
                numerosIV0[0].SetActive(true);
                break;


        }

    }


    //Numeros que ira aparecer quando eu for matando o inimigo 
    public void ChamaContadorCQ()
    {

        contadorX++;
        switch (contadorX)
        {

            case 1:
                numerosIB[0].SetActive(true);
                numerosIB[1].SetActive(false);
                break;

        }

        switch (contadorX)
        {

            case 2:
                numerosIC[0].SetActive(true);
                numerosIC[1].SetActive(false);
                break;

        }

        switch (contadorX)
        {

            case 3:
                numerosID[0].SetActive(true);
                numerosID[1].SetActive(false);
                break;

        }

        switch (contadorX)
        {

            case 4:
                numerosIE[0].SetActive(true);
                numerosIE[1].SetActive(false);
                break;

        }

        switch (contadorX)
        {

            case 5:
                numerosIF[0].SetActive(true);
                numerosIF[1].SetActive(false);
                break;

        }

        switch (contadorX)
        {

            case 6:
                numerosIG[0].SetActive(true);
                numerosIG[1].SetActive(false);
                break;

        }

        switch (contadorX)
        {

            case 7:
                numerosIH[0].SetActive(true);
                numerosIH[1].SetActive(false);
                break;

        }

        switch (contadorX)
        {

            case 8:
                numerosII[0].SetActive(true);
                numerosII[1].SetActive(false);
                break;

        }

        switch (contadorX)
        {

            case 9:
                numerosIJ[0].SetActive(true);
                numerosIJ[1].SetActive(false);
                break;

        }

        switch (contadorX)
        {

            case 10:
                numerosIK[0].SetActive(true);
                numerosIK[1].SetActive(false);
                break;

        }

    }

    //Numero 0 que ira aparecer do inimigo no inicio
    private void MostrarNumerosInimigo()
    {

        switch (contadorZ)
        {

            case 0:
                numerosIA[0].SetActive(true);
                break;


        }

    }

    public void BTSair()
    {
       
        
        Application.Quit();
        // Debug.Log("saio");
    }

    //Numeros que ira aparecer quando eu matar os passaros
    public void ChamaContadorPassaro()
    {

        contadorPV++;
        switch (contadorPV)
        {

            case 1:
                numerosIP1[0].SetActive(true);
                numerosIP1[1].SetActive(false);
                break;

        }

        switch (contadorPV)
        {

            case 2:
                numerosIP2[0].SetActive(true);
                numerosIP2[1].SetActive(false);
                break;

        }

        switch (contadorPV)
        {

            case 3:
                numerosIP3[0].SetActive(true);
                numerosIP3[1].SetActive(false);
                break;

        }
    }

    //Numero 0 que ira aparecer do passaro no inicio
    private void MostrarNumeroPassaro()
    {

        switch (zeroPassaro)
        {

            case 0:
                numerosIP0[0].SetActive(true);
                break;


        }

    }

  
}















