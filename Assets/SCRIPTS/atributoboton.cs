using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum TipoAtributo
{
Fuerza,Inteligencia,Destreza
}

public class atributoboton : MonoBehaviour
{
    public static Action<TipoAtributo> Agregaratributoevento;
    // Start is called before the first frame update
    [SerializeField] private TipoAtributo tipo;
    public void AgregarAtributo()
    {
        Agregaratributoevento?.Invoke(tipo);
    }

}
