using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReservaDeInimigos : MonoBehaviour
{

    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private int quantidade;

    private Stack<GameObject> reservaDeInimigos;

    void Start()
    {
        reservaDeInimigos = new Stack<GameObject>();
        CriarTodosOsInimigos();
    }

    private void CriarTodosOsInimigos()
    {
        for(var i = 0; i < quantidade; i++)
        {
            var inimigo = GameObject.Instantiate(prefab, transform);
            inimigo.GetComponent<ObjetoDaReservaDeInimigos>().SetReservaDeInimigos(this);
            inimigo.SetActive(false);
            reservaDeInimigos.Push(inimigo);
        }
    }

    public GameObject PegarInimigo()
    {
        var inimigo = reservaDeInimigos.Pop();
        inimigo.SetActive(true);
        return inimigo;
    }

    public void DevolverInimigo(GameObject inimigo)
    {
        inimigo.SetActive(false);
        reservaDeInimigos.Push(inimigo);
    }

    public bool TemInimigo()
    {
        return reservaDeInimigos.Count > 0;
    }
}
