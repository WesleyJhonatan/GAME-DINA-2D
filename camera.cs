using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class camera : MonoBehaviour
{

    public GameObject Meujogador;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Seguir();
    }

    void Seguir()
    {
        Vector3 destino = new Vector3(Meujogador.transform.position.x,Meujogador.transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, destino, 0.1f);
    }
}
