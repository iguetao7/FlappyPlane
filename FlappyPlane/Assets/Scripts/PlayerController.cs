using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Infos do player
    private Rigidbody2D meuRB;
    //velocidade 
    [SerializeField] private float velocidade = 5f;
    //Fumaça do aviao
    [SerializeField] private GameObject puff;


    // Start is called before the first frame update
    void Start()
    {
        //usando rigibody quando o jogo inicia
        meuRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Subir apertando espaço
        Subir();
        LimitandoVelocidade();
        MorrendoAoSair();
    }

    private void LimitandoVelocidade()
    {
        //Limitando a velocidade de queda
        if (meuRB.velocity.y < -velocidade)
        {
            //Travando o RB em -5
            meuRB.velocity = Vector2.down * velocidade;
        }
    }

    //Criando metodo de subir
    public void Subir()
    {
        //Subindo ao aperta espaço
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Fazendo a velocidade do RB ir para cima usando ferramenta da unity
            meuRB.velocity = Vector2.up * velocidade;
            //criando o puff em uma variavel
            GameObject meuPuff = Instantiate(puff, transform.position, Quaternion.identity);
            //Destruido o puff
            Destroy(meuPuff, 2f);
        }
    }

    //Reiniciando ao sair da tela
    private void MorrendoAoSair()
    {
        //Checando se saiu da tela
        if (transform.position.y > 5.7f || transform.position.y < -3.3f)
        {
            //Reiniciando o jogo
            SceneManager.LoadScene(0);
        }
    }

    //Colisão 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Recarregando a cena quando bate
        SceneManager.LoadScene("Jogo");
    }
}
