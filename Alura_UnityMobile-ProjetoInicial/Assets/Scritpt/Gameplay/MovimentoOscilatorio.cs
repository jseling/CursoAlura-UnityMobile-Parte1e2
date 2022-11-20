using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoOscilatorio : MonoBehaviour
{
    private Vector3 posicaoInicial;

    [SerializeField]
    private float amplitude;

    [SerializeField]
    private float velocidade;

    private float angulo;

    private void Awake()
    {
        posicaoInicial = transform.position;
    }

    [SerializeField]
    private void Update()
    {
        angulo += velocidade * Time.deltaTime;
        var variacao = Mathf.Sin(angulo);
        transform.position = posicaoInicial + (amplitude * variacao * Vector3.up);
    }
}
