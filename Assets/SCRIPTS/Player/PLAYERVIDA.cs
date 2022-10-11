using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PLAYERVIDA : VIDABASE
{
    public static Action EventoDerrotado;
    public bool puedeSerCurado => vida < vidamaxima;

    public void RestaurarVida(float cantidad)
    {
        if (puedeSerCurado)
        {
            vida += cantidad;
            if(vida > vidamaxima)
            {
                vida = vidamaxima;
            }
            actualizarBarraVida(vida,vidamaxima);
        }
    }

    protected override void playerDerrotado()
    {
        if(EventoDerrotado != null)
        {
            EventoDerrotado.Invoke();
        }
    }

    protected override void Start()
    {
        base.Start();
        actualizarBarraVida(vida, vidamaxima);
    }



    protected override void actualizarBarraVida(float vidaActual, float vidaMaxima)
    {
        UImanager.Instance.Actualizarvidaplayer(vidaActual, vidaMaxima);
    }
    
    // Start is called before the first frame update
  

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            recibirDano(10);
        }


        if (Input.GetKeyDown(KeyCode.B))
        {
            RestaurarVida(10);
        }
    }
}
