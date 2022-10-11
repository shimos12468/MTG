using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PERSONAJEEXPERIENCIA : MonoBehaviour
{


    [SerializeField] private PERSONAJESTATS stats;


    [SerializeField] private int NivelMaximo;
    [SerializeField] private int Experienciabase;
    [SerializeField] private int ValorIncremental;
    // Start is called before the first frame update

    private float experienciaactual;
    private float Experienciaactualtemporal;
    private float Experienciaparasiguientenivel;

    void Start()
    {
        stats.Nivel = 1;
        Experienciaparasiguientenivel = Experienciabase;
        stats.Exprequerida = Experienciaparasiguientenivel;
        Actualizarbarraexperiencia();
    }

    public void Añadirexperiencia(float experienciaobtenida){
        
        if(experienciaobtenida >0f)
        {
            float experienciarestante = Experienciaparasiguientenivel - Experienciaactualtemporal;
            if (experienciaobtenida >= experienciarestante)
            {
                experienciaobtenida -= experienciarestante;
                experienciaactual += experienciaobtenida;
                ActualizarNivel();
                Añadirexperiencia(experienciaobtenida);
            }
            else
            {
                experienciaactual += experienciaobtenida;
                Experienciaactualtemporal += experienciaobtenida;
                if(Experienciaactualtemporal == Experienciaparasiguientenivel)
                {
                    ActualizarNivel();
                }
            }
        }
        stats.Expactual = experienciaactual;
        Actualizarbarraexperiencia();
    }
    private void ActualizarNivel()
    {
        if(stats.Nivel < NivelMaximo)
        {
            stats.Nivel++;
            Experienciaactualtemporal = 0f;
            Experienciaparasiguientenivel *= ValorIncremental;
            stats.Exprequerida = Experienciaparasiguientenivel;
            stats.PuntosDisponibles += 3;
        }

    }

    private void Actualizarbarraexperiencia()
    {
        UImanager.Instance.Actualizarexperienciaplayer(Experienciaactualtemporal, Experienciaparasiguientenivel);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Añadirexperiencia(10f);
        }
    }
}
