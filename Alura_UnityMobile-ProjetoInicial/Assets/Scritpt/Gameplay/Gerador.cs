using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gerador : MonoBehaviour
{
    //[SerializeField]
    //private GameObject prefabInimigo;
    [SerializeField]
    private float tempo;

    [SerializeField]
    private Rect area;

    [SerializeField]
    private Transform alvo;

    [SerializeField]
    private Pontuacao pontuacao;

    [SerializeField]
    private ReservaDeInimigos reservaDeInimigos;

    private void Start()
    {
        //StartCoroutine(this.IniciarGeracao());
        InvokeRepeating("Instanciar", 0f, tempo);
    }

    //private IEnumerator IniciarGeracao()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(this.tempo);
    //        this.Instanciar();
    //    }
    //}

    private void Instanciar()
    {
        //var inimigo = GameObject.Instantiate(this.prefabInimigo);

        if (reservaDeInimigos.TemInimigo())
        {
            var inimigo = reservaDeInimigos.PegarInimigo();
            this.DefinirPosicaoInimigo(inimigo);
            inimigo.GetComponent<Seguir>().SetAlvo(alvo);
            inimigo.GetComponent<Pontuavel>().SetPontuacao(pontuacao);
        }
    }

    private void DefinirPosicaoInimigo(GameObject inimigo)
    {
        //var posicaoAleatoria = new Vector3(
        //                Random.Range(-this.raio, this.raio),
        //                Random.Range(-this.raio, this.raio),
        //                0);

        var posicaoAleatoria = new Vector2(
                Random.Range(this.area.x, this.area.x + this.area.width),
                Random.Range(this.area.y, this.area.y + this.area.height)
            );

        var posicaoInimigo = (Vector2)this.transform.position + posicaoAleatoria;
        inimigo.transform.position = posicaoInimigo;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(100,0,100);
        var posicao = this.area.position + (Vector2)transform.position + this.area.size/2;
        Gizmos.DrawWireCube(posicao, this.area.size);
    }
}
