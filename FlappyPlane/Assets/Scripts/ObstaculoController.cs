using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoController : MonoBehaviour
{
    //velocidade
    [SerializeField] private float velocidade = 4f;

    [SerializeField] private GameObject eu;

    //variavel do game controller do level
    [SerializeField] private GameController game;

    // Start is called before the first frame update
    void Start()
    {
        //Destruindo obstaculos a cada 5 segundos
        Destroy(eu, 5f);

        //Encontrando o gamecontroller da cena atual já que não da  para colocar direto da cena no inspetor
        game = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimentando para a esquerda suavemente
        transform.position += Vector3.left * Time.deltaTime * velocidade;

        //Velocidade mais o level
        velocidade = 4f + game.RetornaLevel();
    }
}
