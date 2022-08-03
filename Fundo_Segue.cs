using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Fundo_Segue : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Personagem;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // posição X
        float posX = Personagem.transform.position.x * 0.93f;
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
    }
}
