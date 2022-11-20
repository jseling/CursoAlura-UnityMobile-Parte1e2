using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguir : MonoBehaviour
{
    [SerializeField]
    private Transform alvo;

    [SerializeField]
    private float forca;

    private Rigidbody2D fisica;

    // Start is called before the first frame update
    void Awake()
    {
        fisica = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var deslocamento = alvo.position - transform.position;
        deslocamento.Normalize();
        deslocamento *= forca;

        //transform.position += deslocamento * velocidade * Time.deltaTime;

        fisica.AddForce(deslocamento, ForceMode2D.Force);
    }

    public void SetAlvo(Transform novoAlvo)
    {
        alvo = novoAlvo;
    }
}
