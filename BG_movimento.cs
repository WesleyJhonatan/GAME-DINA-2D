using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BG_movimento : MonoBehaviour
{

    //variavel de velocidade
     
    public float velocidade_cenario;
        
    private MeshRenderer renderizador;

    // Start is called before the first frame update
    void Start()
    {
        renderizador = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float posX = Mathf.Repeat(Time.time * velocidade_cenario, 1);
        Vector2 offset = new Vector2(posX, 0);
        renderizador.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
