using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Collections.ObjectModel;

public class Ranking : MonoBehaviour
{
    private static readonly string NOME_DO_ARQUIVO = "Ranking.json";

    [SerializeField]
    private List<Colocado> listaDeColocados;

    private string caminhoArquivo;

    void Awake()
    {
        caminhoArquivo = Path.Combine(Application.persistentDataPath, NOME_DO_ARQUIVO);

        if (File.Exists(caminhoArquivo))
        {
            var textoJson = File.ReadAllText(caminhoArquivo);

            JsonUtility.FromJsonOverwrite(textoJson, this);
        }
        else
        {
            listaDeColocados = new List<Colocado>();
        }
    }

    public string AdicionarPontuacao(int pontos, string nome)
    {
        var id = Guid.NewGuid().ToString();
        var novoColocado = new Colocado(nome, pontos, id);
        this.listaDeColocados.Add(novoColocado);
        listaDeColocados.Sort();
        SalvarRanking();
        return id;
    }

    public void AlterarNome(string nome, string id)
    {
        //listaDeColocados[id].nome = nome;

        foreach(var item in listaDeColocados)
        {
            if(item.id == id)
            {
                item.nome = nome;
                break;
            }
        }
        SalvarRanking();
    }

    private void SalvarRanking()
    {
        var textoJson = JsonUtility.ToJson(this);
        File.WriteAllText(caminhoArquivo, textoJson);
        //Debug.Log(Application.persistentDataPath);
    }

    public ReadOnlyCollection<Colocado> GetColocados()
    {
        return listaDeColocados.AsReadOnly();
    }
}

[System.Serializable]
public class Colocado: IComparable
{
    public string nome;
    public int pontos;
    public string id;

    public Colocado(string nome, int pontos, string id)
    {
        this.nome = nome;
        this.pontos = pontos;
        this.id = id;
    }

    public int CompareTo(object obj)
    {
        //-1 se este vem antes do outro
        //0 se este é igual ao outro
        //1 se este vem depois do outro
        var outroObjeto = obj as Colocado;
        return outroObjeto.pontos.CompareTo(pontos);//usar o compare do outro para inverter a ordenação (fazer decrescente)
    }
}