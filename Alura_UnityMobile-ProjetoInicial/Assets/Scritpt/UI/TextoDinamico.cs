using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoDinamico : MonoBehaviour
{
    private Text texto;
    // Start is called before the first frame update
    void Awake()
    {
        texto = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtualizarTexto(int numero)
    {
        texto.text = numero.ToString();
    }

    public void AtualizarTexto(string novoTexto)
    {
        texto.text = novoTexto;
    }
}
