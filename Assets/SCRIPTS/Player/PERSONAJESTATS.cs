using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="stats")]
public class PERSONAJESTATS : ScriptableObject
{
    public enum Rarity { Common, Uncommon, Rare, Epic, Legendary }
    public enum Type { Fire, Dark, Light, Metal, Water, Nature, Wind, Poison, Melee, Bug, Rock }
    
    public string description;
    public string name;
    public Sprite heroIcon;
    public float Daño = 5f;
    public float Defensa = 2F;
    public float Velocidad = 5f;
    public int Nivel;
    public float Expactual;
    public float Exprequerida;
    [Range(0f, 100f)] public float PorcentajeCritico;
    [Range(0f, 100f)] public float PorcentajeBloqueo;
    public int baseHealth;
    public float healthMultiplier;

    public int Fuerza;
    public int Destreza;
    public int Inteligencia;
    [HideInInspector] public int PuntosDisponibles;


    public void AñadirmejoraFuerza()
    {
        Daño += 2f;
        Defensa += 1f;
        PorcentajeBloqueo += 0.04f;
    }
    public void Añadirmejorainteligencia()
    {
        Daño += 3f;
        PorcentajeCritico += 0.2f;
    }
    public void Añadirmejoradestreza()
    {
        Velocidad += 0.1f;
        PorcentajeBloqueo += 0.05f;
    }
    public void ResetearValores()
    {
        Daño = 5f;
        Defensa = 2f;
        Velocidad = 5f;
        Nivel = 1;
        Expactual = 0f;
        Exprequerida = 0f;
        PorcentajeBloqueo = 0f;
        PorcentajeCritico = 0f;

        Fuerza = 0;
        Inteligencia = 0;
        Destreza = 0;

        PuntosDisponibles = 0;

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
