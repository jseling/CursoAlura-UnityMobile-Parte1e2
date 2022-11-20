using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlePause : MonoBehaviour
{
    [SerializeField]
    private GameObject painelPause;

    [SerializeField, Range(0,1)]
    private float escalaTempoPause;

    private bool jogoEstaParado;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EstaoTocandoNaTela())
        {
            if (jogoEstaParado)
            {
                ContinuarJogo();
            }
        }
        else
        {
            if (!jogoEstaParado)
            {
                PararJogo();
            }
        }
    }

    private void ContinuarJogo()
    {
        StartCoroutine(EsperarEContinuarOJogo());
    }

    private IEnumerator EsperarEContinuarOJogo()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        painelPause.SetActive(false);
        MudarEscalaDeTempo(1);
        jogoEstaParado = false;
    }

    private void PararJogo()
    {
        painelPause.SetActive(true);
        MudarEscalaDeTempo(escalaTempoPause);
        jogoEstaParado = true;
    }

    private bool EstaoTocandoNaTela()
    {
        return Input.touchCount > 0;
    }

    private void MudarEscalaDeTempo(float escala)
    {
        Time.timeScale = escala;
        Time.fixedDeltaTime = 0.02f * escala;
    }
}
