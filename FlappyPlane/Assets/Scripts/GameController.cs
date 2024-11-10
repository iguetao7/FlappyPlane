using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //Timer
    [SerializeField] private float timer = 1f;

    //Meu obstaculo
    [SerializeField] private GameObject obstaculo;
    //Posição de criação do obstaculo
    [SerializeField] private Vector3 posicao;
    //Posição maxima e minima de criação
    [SerializeField] private float posMin = -0.3f;
    [SerializeField] private float posMax = 2.4f;
    //Intevalo de tempo da criaçao de obstaculo
    [SerializeField] private float tempMin = 1f;
    [SerializeField] private float tempMax = 3f;

    //Pontuaçao inical
    private float pontos = 0;
    //Pontos no canva
    [SerializeField] private Text pontosTexto;

    //Levels
    private int level = 1;
    //Pontos para passar de level
    [SerializeField] private float proximoLevel = 10f;
    //
    [SerializeField] private Text levelTexto;
    //Som
    [SerializeField] private AudioClip levelUp;
    //Posição de onde vai tocar o som
    private Vector3 camPos;


    // Start is called before the first frame update
    void Start()
    {
        //Pegando posição da camera onde o som vai tocar
        camPos = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Pontos();
        CriaObstaculo();
        GanhaLevel();
    }

    private void Pontos()
    {
        //Pontuação
        pontos += Time.deltaTime;
        //Passando os pontos para textos
        pontosTexto.text = Mathf.Round(pontos).ToString();
    }

    //Passando de level
    private void GanhaLevel()
    {
        //Mostrando o level
        levelTexto.text = level.ToString();
        if (pontos > proximoLevel)
        {
            //Tocando som ao passar de nivel
            AudioSource.PlayClipAtPoint(levelUp, camPos);
            //Aumentando o level
            level++;
            //Dobrando o valor do proximo level
            proximoLevel *= 2;
        }
    }

    private void CriaObstaculo()
    {
        //tempo de criaçao de obstaculo
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            //intervalo de tmepo de craiação de obstaculos
            timer = Random.Range(tempMin / level, tempMax);
            //Posição aleatoria para os obstaculos
            posicao.y = Random.Range(posMin, posMax);
            //Obstaculo na posição e com a rotação que ja tem
            Instantiate(obstaculo, posicao, Quaternion.identity);
        }
    }

    //Retorno do levelpara aumento de dificuldade de obstaculso
    public int RetornaLevel()
    {
        return level;
    }

}
