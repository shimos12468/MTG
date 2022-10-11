using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PERSONAJE : MonoBehaviour

{
    [SerializeField] private PERSONAJESTATS stats;

    public PLAYERVIDA pLAYERVIDA { get; private set; }
    public PERSONAJEMANA pERSONAJEMANA { get; private set; }

    private void Awake()
    {
        pLAYERVIDA = GetComponent<PLAYERVIDA>();
        pERSONAJEMANA = GetComponent<PERSONAJEMANA>();
    }


   private void atributoRespuesta(TipoAtributo tipo)
    {

        if(stats.PuntosDisponibles <= 0)
        {
            return;
        }

        switch (tipo)
        {
            case TipoAtributo.Fuerza:
                stats.Fuerza++;
                stats.AñadirmejoraFuerza();
                break;
            case TipoAtributo.Destreza:
                stats.Destreza++;
                stats.Añadirmejoradestreza();
                break;
            case TipoAtributo.Inteligencia:
                stats.Inteligencia++;
                stats.Añadirmejorainteligencia();
                break;
        }
        stats.PuntosDisponibles -= 1;
    }

    private void OnEnable()
    {
        atributoboton.Agregaratributoevento += atributoRespuesta; 
    }
    private void OnDisable()
    {
        atributoboton.Agregaratributoevento -= atributoRespuesta;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
