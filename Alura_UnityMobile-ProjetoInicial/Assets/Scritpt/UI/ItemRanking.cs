using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemRanking : MonoBehaviour
{
    [SerializeField]
    private Text textoColocacao, textoNome, textoPontuacao;

    public void Configurar(int colocacao, string nome, int pontuacao)
    {
        textoColocacao.text = colocacao.ToString();
        textoNome.text = nome;
        textoPontuacao.text = pontuacao.ToString();
    }
}
