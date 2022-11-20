using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovaPontuacao : MonoBehaviour
{
    [SerializeField]
    private TextoDinamico textoPontuacao;

    [SerializeField]
    private TextoDinamico textoNome;

    private Pontuacao pontuacao;

    [SerializeField]
    private Ranking ranking;

    private string id;

    // Start is called before the first frame update
    void Start()
    {
        string nomeDaPessoa = GetNome();
        int totalPontos = GetPontuacao();
        textoPontuacao.AtualizarTexto(totalPontos);
        textoNome.AtualizarTexto(nomeDaPessoa);
        id = ranking.AdicionarPontuacao(totalPontos, nomeDaPessoa);
    }

    private string GetNome()
    {
        if (PlayerPrefs.HasKey("UltimoNome"))
        {
            return PlayerPrefs.GetString("UltimoNome");
        }
        return "Nome";
    }

    private int GetPontuacao()
    {
        pontuacao = GameObject.FindObjectOfType<Pontuacao>();

        var totalPontos = -1;
        if (pontuacao != null)
        {
            totalPontos = pontuacao.Pontos;
        }

        return totalPontos;
    }

    public void AlterarNome(string nome)
    {
        ranking.AlterarNome(nome, id);
        PlayerPrefs.SetString("UltimoNome", nome);
    }
}
