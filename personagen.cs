using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

public class personagen : MonoBehaviour
{

    /// variaveis
    /// pega o componente Rigidbody2D
    public Rigidbody2D Corpo;

    /// recebe a velocidade do personagen 

    public float velocidade;

    /// pega o componente Sprit Renderer

    public SpriteRenderer ImagemPersonagem;


    /// quantidades de pulos que meu personagen realizou

    public int qtd_pulo = 0;

    // controlar quando eu possopukar novamente

    private float meutempopulo = 0;

    //boleana que me diz se posso pular;

    public bool podepular = true;

    // vida do personagem

    public int vida = 10;

    private float meutempoDano = 0;

    private bool podeDano = true;

    //Barra de HP

    private Image BarraHp;

    // medalha

    public int medalha = 0;

    private Text medalha_texto;

    //disparo da bala 

    public GameObject Bala;

    private float meuTempoTiro = 0;

    private bool pode_atirar = true;

    public int municao = 5;

    private Text Municao_texto;

    public GameObject Arma_Personagem;

    // Chances de jogo

    private int chances = 3;
    private Text Chances_texto;

    //POSIÇÃO INICIAL

    public Vector3 minhaPosInicial = new Vector3(-7.97f, -3.69f, 0);

    //controla o jogo

    private GerenciadorJogo GJ;

    //Pegar o Animator

    private Animator Animacao;

    public GameObject Morte;

    public List<GameObject> Coracoes;

    public GameObject TiroAnimacao;

    //Quando pega a chave pode vencer fica true

    private bool podeVencer = false;

    //Palavra que ira aparece quando pegar a presidente

    public List<GameObject> parabens;
    private int Ativaswitch = 0;

    //Som Do Personagem Andando
    public AudioSource Passos;
    private float VolumePassos = 0;

    //Som Do Personagem Pulando
    public AudioSource Spulando;

    //Som Morte
    public AudioSource Smorte;

    //Som Rasteira
    public AudioSource Srasteira;

    //Som Corrente
    public AudioSource Scorrente;

    //Som Corrente
    public AudioSource SDano;


    //numeros que ira aparecer quando pegar as moedas

    public List<GameObject> numerosM0;
    public List<GameObject> numerosM1;
    public List<GameObject> numerosM2;
    public List<GameObject> numerosM3;
    public List<GameObject> numerosM4;
    public List<GameObject> numerosM5;
    public List<GameObject> numerosM6;
    public List<GameObject> numerosM7;
    public List<GameObject> numerosM8;
    public List<GameObject> numerosM9;
    public List<GameObject> numerosM10;
    public List<GameObject> numerosM11;
    public List<GameObject> numerosM12;
    public List<GameObject> numerosM13;
    public List<GameObject> numerosM14;
    public List<GameObject> numerosM15;
    public List<GameObject> numerosM16;
    public List<GameObject> numerosM17;
    public List<GameObject> numerosM18;
    public List<GameObject> numerosM19;
    public List<GameObject> numerosM20;
    public List<GameObject> numerosM21;
    public List<GameObject> numerosM22;
    public List<GameObject> numerosM23;
    public List<GameObject> numerosM24;
    public List<GameObject> numerosM25;
    public List<GameObject> numerosM26;
    public List<GameObject> numerosM27;
    public List<GameObject> numerosM28;
    public List<GameObject> numerosM29;
    public List<GameObject> numerosM30;
    private int contamoedas = 0;

    public float VelocidadeExterna;

    // Start is called before the first frame update
    void Start()
    {
      
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorJogo>();

        //Animacao recebe componente

        Animacao = GetComponent<Animator>();

        transform.position = minhaPosInicial;

        BarraHp = GameObject.FindGameObjectWithTag("hp_barra").GetComponent<Image>();
        medalha_texto = GameObject.FindGameObjectWithTag("medalha_texto_tag").GetComponent<Text>();

        Municao_texto = GameObject.FindGameObjectWithTag("Municao_texto_tag").GetComponent<Text>();
        Municao_texto.text = municao.ToString();
        Chances_texto = GameObject.FindGameObjectWithTag("Chance_texto_tag").GetComponent<Text>();
        Chances_texto.text = "Vidas:" + chances.ToString();

        MostrarNumerosMoedas();

    }

    // Update is called once per frame
    void Update()
    {
        if (GJ.EstadoDoJogo() == true)

        {

            Mover();
            Pular();
            Apontar();
            Dano();
            Atirar();
           

            if (vida < 0)
            {

                Morrer();

            }
        }


    }


    //responsavel por mover o personagen
    void Mover()
    {

        velocidade = Input.GetAxis("Horizontal") * 3;
        Passos.volume = velocidade * 3;
        
        Corpo.velocity = new Vector2(velocidade + VelocidadeExterna, Corpo.velocity.y);

        if (velocidade != 0)

        {


            Animacao.SetBool("Andando", true);


        }

        else

        {
            //Parado
            Animacao.SetBool("Andando", false);


        }

        //Subindo

       

        if (Corpo.velocity.y > 1)

        {
            
            Animacao.SetBool("Caindo", false);
            Animacao.SetBool("ForaDoChao", true);

        }

        //Caindo

        if (Corpo.velocity.y < -2)

        {
            
            Animacao.SetBool("Caindo", true);
            Animacao.SetBool("ForaDoChao", true);

        }

        // Rasteira
        if (Input.GetKeyDown(KeyCode.C))
        {
            Srasteira.volume = 1;
            Passos.volume = 0;
            GetComponent<BoxCollider2D>().size = new Vector2(0.79f, 0.70f);
            Animacao.SetBool("Deitado", true);
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            Passos.volume = 0;
            Srasteira.volume = 0;
            GetComponent<BoxCollider2D>().size = new Vector2(0.79f, 1.64f);
            Animacao.SetBool("Deitado", false);
            
        }

        //Correndo

        if (Input.GetKey(KeyCode.Z))
        {
            // liga o som do passos
            Passos.pitch = 2;

            Corpo.velocity = new Vector2(velocidade * 2, Corpo.velocity.y);
            Animacao.SetBool("Correndo", true);

        }

        if (Input.GetKeyUp(KeyCode.Z))
        {

            Passos.pitch = 1;
            Corpo.velocity = new Vector2(velocidade * 2, Corpo.velocity.y);
            Animacao.SetBool("Correndo", false);


        }




    }


    // responsavel por mover o personagen
    void Apontar()

    {
        //Altera Baseado na velocidade
        VolumePassos = velocidade;
        if (velocidade > 0)
        {
           
            ImagemPersonagem.flipX = false;

        }
        else if (velocidade < 0)
        {
            ImagemPersonagem.flipX = true;
            VolumePassos = VolumePassos * -1;
        }

        Passos.volume = VolumePassos * 1;
    }

    void Pular()
    {
        if (Input.GetKeyDown(KeyCode.Space) && podepular == true)
        {
           
            podepular = false;
            qtd_pulo++;
            if (qtd_pulo <= 2)

            {

                
                AcaoPulo();
            }


        }
        if (podepular == false)

        {
            
            temporizadorpulo();

        }


    }


    void AcaoPulo()
    {
        
        // zera velocidade de queda para pulo
        Corpo.velocity = new Vector2(velocidade, 0);
        // adiciona forã para pular
        Corpo.AddForce(transform.up * 300f);
    }

    void OnTriggerStay2D(Collider2D gatilho)

    {

        if (gatilho.gameObject.tag == "Chao")
        {
            Spulando.volume = 0;
            Animacao.SetBool("ForaDoChao", false);
        }


        if (gatilho.gameObject.tag == "ventilador2")
        {
            //escolhe a força do ventilador
            Corpo.AddForce(transform.right * -20);

        }

        if (gatilho.gameObject.tag == "ventilador")

        {
            
            AcaoPulo();

        }

        if (gatilho.gameObject.tag == "Blocoazul")
        {
            Scorrente.volume = 1;
        }
    }

   
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Blocoazul")
        {
            Scorrente.volume = 0;
        }
    }


    // gatilhos


    void OnTriggerEnter2D(Collider2D gatilho)

    {

        if (gatilho.gameObject.tag == "Chao")
        {
            Spulando.volume = 0;
            qtd_pulo = 0;
            podepular = true;
            meutempopulo = 0;
        }

        if (gatilho.gameObject.tag == "medalha")

        {

            //Destroy(gatilho.gameObject);
            medalha++;
            medalha_texto.text = medalha.ToString();
            switch (medalha)
            {
                case 1:
                    numerosM1[0].SetActive(true);
                    numerosM1[1].SetActive(false);
                    break;

            }

            switch (medalha)
            {

                case 2:
                    numerosM2[0].SetActive(true);
                    numerosM2[1].SetActive(false);
                    break;

            }

            switch (medalha)
            {

                case 3:
                    numerosM3[0].SetActive(true);
                    numerosM3[1].SetActive(false);
                    break;

            }

            switch (medalha)
            {

                case 4:
                    numerosM4[0].SetActive(true);
                    numerosM4[1].SetActive(false);
                    break;

            }

            switch (medalha)
            {

                case 5:
                    numerosM5[0].SetActive(true);
                    numerosM5[1].SetActive(false);
                    break;

            }

            switch (medalha)
            {

                case 6:
                    numerosM6[0].SetActive(true);
                    numerosM6[1].SetActive(false);
                    break;

            }

            switch (medalha)
            {

                case 7:
                    numerosM7[0].SetActive(true);
                    numerosM7[1].SetActive(false);
                    break;

            }

            switch (medalha)
            {

                case 8:
                    numerosM8[0].SetActive(true);
                    numerosM8[1].SetActive(false);
                    break;

            }

            switch (medalha)
            {

                case 9:
                    numerosM9[0].SetActive(true);
                    numerosM9[1].SetActive(false);
                    break;

            }

            switch (medalha)
            {

                case 10:
                    numerosM10[0].SetActive(true);
                    numerosM10[1].SetActive(false);
                    break;

            }

            switch (medalha)
            {

                case 11:
                    numerosM11[0].SetActive(true);
                    numerosM11[1].SetActive(false);
                    break;

            }

            switch (medalha)
            {

                case 12:
                    numerosM12[0].SetActive(true);
                    numerosM12[1].SetActive(false);
                    break;

            }

            switch (medalha)
            {

                case 13:
                    numerosM13[0].SetActive(true);
                    numerosM13[1].SetActive(false);
                    break;

            }

            switch (medalha)
            {

                case 14:
                    numerosM14[0].SetActive(true);
                    numerosM14[1].SetActive(false);
                    break;

            }

            switch (medalha)
            {

                case 15:
                    numerosM15[0].SetActive(true);
                    numerosM15[1].SetActive(false);
                    break;

            }

            switch (medalha)
            {

                case 16:
                    numerosM16[0].SetActive(true);
                    numerosM16[1].SetActive(false);
                    break;

            }

            switch (medalha)
            {

                case 17:
                    numerosM17[0].SetActive(true);
                    numerosM17[1].SetActive(false);
                    break;

            }

            switch (medalha)
            {

                case 18:
                    numerosM18[0].SetActive(true);
                    numerosM18[1].SetActive(false);
                    break;

            }

            switch (medalha)
            {

                case 19:
                    numerosM19[0].SetActive(true);
                    numerosM19[1].SetActive(false);
                    break;

            }

            switch (medalha)
            {

                case 20:
                    numerosM20[0].SetActive(true);
                    numerosM20[1].SetActive(false);
                    break;

            }

            switch (medalha)
            {

                case 21:
                    numerosM21[0].SetActive(true);
                    numerosM21[1].SetActive(false);
                    break;

            }

            switch (medalha)
            {

                case 22:
                    numerosM22[0].SetActive(true);
                    numerosM22[1].SetActive(false);
                    break;

            }

            switch (medalha)
            {

                case 23:
                    numerosM23[0].SetActive(true);
                    numerosM23[1].SetActive(false);
                    break;

            }

            switch (medalha)
            {

                case 24:
                    numerosM24[0].SetActive(true);
                    numerosM24[1].SetActive(false);
                    break;

            }

            switch (medalha)
            {

                case 25:
                    numerosM25[0].SetActive(true);
                    numerosM25[1].SetActive(false);
                    break;

            }

            switch (medalha)
            {

                case 26:
                    numerosM26[0].SetActive(true);
                    numerosM26[1].SetActive(false);
                    break;

            }

            switch (medalha)
            {

                case 27:
                    numerosM27[0].SetActive(true);
                    numerosM27[1].SetActive(false);
                    break;

            }

            switch (medalha)
            {

                case 28:
                    numerosM28[0].SetActive(true);
                    numerosM28[1].SetActive(false);
                    break;

            }

            switch (medalha)
            {

                case 29:
                    numerosM29[0].SetActive(true);
                    numerosM29[1].SetActive(false);
                    break;

            }

            switch (medalha)
            {

                case 30:
                    numerosM30[0].SetActive(true);
                    numerosM30[1].SetActive(false);
                    break;

            }
        }

        if (gatilho.gameObject.tag == "nova_municao")

        {

            municao = municao + 4;
            Municao_texto.text = municao.ToString();
            //Destroy(gatilho.gameObject);

        }

        if (gatilho.gameObject.tag == "chekpoint")

        {

            minhaPosInicial = gatilho.gameObject.transform.position;
            //Destroy(gatilho.gameObject);
        }



        // pega a chave

        if (gatilho.gameObject.tag == "chave")
        {

            podeVencer = true;

        }

        //ganhou

        if (podeVencer == true)
        {
            if (gatilho.gameObject.tag == "vencedor")
            {
                GJ.PersonagemGanhou();

                Passos.volume = 0;
                Spulando.volume = 0;
                Smorte.volume = 0;
            }

        }


        //pega presidente

        if (podeVencer == true)
        {
            if (gatilho.gameObject.tag == "Presidente")
            {
                Ativaswitch++;
                MostrarParabens();
            }

        }

    }

   
    private void MostrarNumerosMoedas()
    {

        switch (contamoedas)
        {

            case 0:
                numerosM0[0].SetActive(true);
                break;


        }

    }



    void MostrarParabens()
    {
        
        switch (Ativaswitch)
        {

            case 1:
                parabens[0].SetActive(true);
                break;

           
        }
    }

    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Blocoazul")
        {
            Animacao.SetBool("ForaDoChao", false);
            qtd_pulo = 0;
            podepular = true;
            meutempopulo = 0;
        }

        if (collision.gameObject.tag == "espinho")

        {
           
            if (podeDano == true)
            {
                podeDano = false;
                Morrer();

            }



        }

    }

    // controlar tempo para pular novamente

    void temporizadorpulo()

    {
        
        meutempopulo += Time.deltaTime;
        if (meutempopulo > 0.5f)
        {
            podepular = true;
            meutempopulo = 0;
        }
    }

    // dano

    void Dano()
    {
        if (podeDano == false)
        {
            temporizadorDano();
        }
    }

    // verifica dano
    // colisoes fisicas

    void OnCollisionStay2D(Collision2D colisao)
    {
       

        if (colisao.gameObject.tag == "inimigo")

            if (podeDano == true)

            {
                VerificaAlan(colisao.gameObject.transform.position.x);
                vida--;
                Animacao.SetBool("Dano", true);
                SDano.volume = 1;
                perderHp();
                podeDano = false;
                ImagemPersonagem.color = UnityEngine.Color.red;

                // So morro se minha vida for menor igual 0

                if (vida <= 0)

                {

                    Morrer();


                }

            }

        if (colisao.gameObject.tag == "boss")
            if (podeDano == true)

            {
                VerificaAlan(colisao.gameObject.transform.position.x);
                vida--;
                Animacao.SetBool("Dano", true);
                perderHp();
                podeDano = false;
                ImagemPersonagem.color = UnityEngine.Color.red;

                // So morro se minha vida for menor igual 0

                if (vida <= 0)

                {

                    Morrer();


                }

            }

        if (colisao.gameObject.tag == "Plataforma")
        {
            VelocidadeExterna = colisao.gameObject.GetComponent<PlataformaDireitaEsquerda>().PlataformaMove();
            Animacao.SetBool("ForaDoChao", false);
         
            qtd_pulo = 1;

            
        }

    }

    
    private void OnCollisionExit2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Plataforma")
        {
            VelocidadeExterna = 0;
        }
    }

    //Empurra personagem

    void VentoEmpurra()
        {

            Corpo.AddForce(transform.right * -100f);

        }

        void VerificaAlan(float posXinimigo)
        {
            //eu estou <-------

            if (posXinimigo >= transform.position.x)
            {

                //Corpo.velocity = new Vector2(-30, 0);
                Corpo.AddForce(transform.right * -2000f);
                // transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);

            }

            //eu estou -------->

            else


            {

                Corpo.AddForce(transform.right * 2000f);

                //transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z);

            }

        }

        //tempo dano
        void temporizadorDano()

        {
            meutempoDano += Time.deltaTime;
            if (meutempoDano > 0.5f)
            {
                SDano.volume = 0;
                podeDano = true;
                meutempoDano = 0;
                ImagemPersonagem.color = UnityEngine.Color.white;

                Animacao.SetBool("Dano", false);
            }
        }
        // Tira HP na HUD
        void perderHp()

        {
            float vida_parabarra = vida * 9.4f;
            BarraHp.rectTransform.sizeDelta = new Vector2(vida_parabarra, 3);
        }

        //Atirar Balas

        void Atirar()

        {
            if (pode_atirar == true)

            {

            if (Input.GetKeyDown(KeyCode.X))
                {

                GetComponent<SpriteRenderer>().enabled = false;
                TiroAnimacao.SetActive(true);
                
                if (municao == 0)
                {

                        GetComponent<SpriteRenderer>().enabled = true;
                        TiroAnimacao.SetActive(false);

                }

                    Arma_Personagem.SetActive(true);

                    // controle de munição

                    if (municao > 0)

                    {
                        municao--;
                        Municao_texto.text = municao.ToString();
                        pode_atirar = false;


                        Disparo();

                    }

               
                }
            }

            

            else

            {

                temporizadorTiro();

            }


        }

        

        //Disparo bala
        void Disparo()

        {
            if (ImagemPersonagem.flipX == false)
            {

            //direção.......>

            //posição que minha bala sai

            Vector3 pontoDisparo = new Vector3(transform.position.x + 0.7f, transform.position.y + 0.4f, transform.position.z);
            GameObject BalaDisparada = Instantiate(Bala, pontoDisparo, Quaternion.identity);
            BalaDisparada.GetComponent<ControleBala>().DirecaoBala(0.09f);

            // ------->

            Arma_Personagem.GetComponent<SpriteRenderer>().flipX = false;

                TiroAnimacao.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

                //destruir bala

                Destroy(BalaDisparada, 2f);

            }


            if (ImagemPersonagem.flipX == true)

            {


            //direção  <.......

            //posição que minha bala sai

            Vector3 pontoDisparo = new Vector3(transform.position.x - 0.7f, transform.position.y + 0.4f, transform.position.z);
            GameObject BalaDisparada = Instantiate(Bala, pontoDisparo, Quaternion.identity);
            BalaDisparada.GetComponent<ControleBala>().DirecaoBala(-0.09f);

            // <-------

            Arma_Personagem.GetComponent<SpriteRenderer>().flipX = true;

                TiroAnimacao.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));

                // destruir bala

                Destroy(BalaDisparada, 2f);

            }

        }

        void temporizadorTiro()

        {
            meuTempoTiro += Time.deltaTime;
            if (meuTempoTiro > 0.5f)

            {
                pode_atirar = true;
                meuTempoTiro = 0;


                GetComponent<SpriteRenderer>().enabled = true;
                TiroAnimacao.SetActive(false);
            }


        }

        //Morte 

        void Morrer()

        {
            chances--;
            Chances_texto.text = "Vidas:" + chances.ToString();


            //So reinicia quando acabar as chances

            if (chances <= 0)
            {
                GetComponent<SpriteRenderer>().enabled = false;
                Morte.SetActive(true);
                 GJ.PersonagemMorreu();

                Passos.volume = 0;
                Spulando.volume = 0;
                Smorte.volume = 0;

            }

            else
            {
                //Inicializar();

                GetComponent<SpriteRenderer>().enabled = false;
                Morte.SetActive(true);

                Smorte.volume = 1;

            }

        }





    private void MostrarCoracao()
    {

        switch (chances)
        {

            case 1:
                Coracoes[0].SetActive(true);
                Coracoes[1].SetActive(false);
                Coracoes[2].SetActive(false);
                break;
            case 2:
                Coracoes[0].SetActive(true);
                Coracoes[1].SetActive(true);
                Coracoes[2].SetActive(false);
                break;
            case 3:
                Coracoes[0].SetActive(true);
                Coracoes[1].SetActive(true);
                Coracoes[2].SetActive(true);
                break;

        }

    }

        //iniciar o jogo

        public void Inicializar()

        {

            
             MostrarCoracao();
            Morte.SetActive(false);
            GetComponent<SpriteRenderer>().enabled = true;
            //muda a posição do personagem
            transform.position = minhaPosInicial;
            //Recuperar vida

            vida = 10;


            float vida_parabarra = vida * 9.4f;
            BarraHp.rectTransform.sizeDelta = new Vector2(vida_parabarra, 3);
        }

    void SomPULANDO()
    {
       
        Spulando.volume = 1;

    }

    void SomCAINDO()
    {

        Spulando.volume = 0;
    }

    public void SomMorte()
    {
        Smorte.volume = 0;
    }

}
