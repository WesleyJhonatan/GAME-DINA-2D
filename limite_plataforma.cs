using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class limite_plataforma : MonoBehaviour
{
    private GerenciadorJogo GJ;
    public GameObject Objeto;
    public GameObject Objeto2;
    //public GameObject Objet2;
    // Start is called before the first frame update
    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorJogo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        {
            LimiteY();
        }
    }

    void LimiteY()

    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (transform.position.y < Objeto.transform.position.y + 0)
        {
            float posY = UnityEngine.Random.Range(-3.88f, 1.93f);

            transform.position = new Vector3(transform.position.x, Objeto2.transform.position.y + 0 + posY, transform.position.z);

        }
    }

  
}
