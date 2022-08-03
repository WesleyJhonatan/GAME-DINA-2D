using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOMFUMACA : MonoBehaviour
{
    //Som Ventilador
    public AudioSource Fumaca;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter2D(Collider2D gatilho)
    {
        if (gatilho.gameObject.tag == "Player")

        {
          
            Fumaca.volume = 1;
           
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Fumaca.volume = 0;
        }
    }

    
}
