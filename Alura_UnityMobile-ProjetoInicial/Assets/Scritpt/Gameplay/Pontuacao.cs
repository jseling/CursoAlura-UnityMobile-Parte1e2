using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pontuacao : MonoBehaviour
{
    public int Pontos { get; private set; }

    [SerializeField]
    private MeuEventoPersonalizadoInt aoPontuar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pontuar()
    {
        Pontos++;
        aoPontuar.Invoke(Pontos);
    }


}

[System.Serializable]
public class MeuEventoPersonalizadoInt : UnityEvent<int>
{

}