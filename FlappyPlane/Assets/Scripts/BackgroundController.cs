using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    //Pegando o material
    private Renderer meuFundo;
    //Posição x do offset
    private float xOffset = 0f;
    //Posição da textura
    private Vector2 texturaOffset;
    //Velocidade do fundo
    [SerializeField] private float velocidade = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        //Pegando o fundo
        meuFundo = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Diminuindo o calor do xOffset
        xOffset += Time.deltaTime * velocidade;
        //Passando o xOffset para o eixo x da textura
        texturaOffset.x = xOffset;
        //Movendo o x do offset do renderer
        meuFundo.material.mainTextureOffset = texturaOffset;
    }
}
