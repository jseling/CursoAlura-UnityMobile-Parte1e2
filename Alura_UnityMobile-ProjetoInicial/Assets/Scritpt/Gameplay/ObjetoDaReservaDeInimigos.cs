using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoDaReservaDeInimigos : MonoBehaviour
{
    private ReservaDeInimigos reservaDeInimigos;

    public void SetReservaDeInimigos(ReservaDeInimigos reserva)
    {
        reservaDeInimigos = reserva;
    }

    public void DevolverParaReserva()
    {
        reservaDeInimigos.DevolverInimigo(gameObject);
    }
}
