using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pontuavel : MonoBehaviour
{


    private Pontuacao pontuacao;
    // Start is called before the first frame update
    void Start()
    {
        //pontuacao = GameObject.FindObjectOfType<Pontuacao>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pontuar()
    {
        pontuacao.Pontuar();

    }

    public void SetPontuacao(Pontuacao pontuacao)
    {
        this.pontuacao = pontuacao;
    }
}
