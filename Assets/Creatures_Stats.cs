using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Creatures_Stats : MonoBehaviour
{
    public enum Raritys { Common, Uncommon, Rare, Epic, Legendary }
    public GameObject evolvecreature;
    public enum Types { Fire, Dark, Light, Metal, Water, Nature, Wind, Poison, Melee, Bug, Rock ,Electric }
    public string type1="";
    public int baselavel = -1;
    public int evolutionlevel = -3;
    public string type2="";
    public string Rarity;
    public string description;
    public string name;
    public Sprite heroIcon;
    public float Damage = 5f;
    public float Magic;
    public float baseMagic;
    public float Health;
    public float Defensa = 2F;
    public float Velocidad = 5f;
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


    public int level = 0;
    public TMP_Text health;
    public TMP_Text magic;
    public TMP_Text experiance;
    public TMP_Text Name;
    public TMP_Text LEVEL;
    public Image img;
    // Start is called before the first frame update
    public void AñadirmejoraFuerza()
    {

        Damage += 2f;
        Defensa += 1f;
        PorcentajeBloqueo += 0.04f;
    }
    public void Añadirmejorainteligencia()
    {
        Damage += 3f;
        PorcentajeCritico += 0.2f;
    }
    public void Añadirmejoradestreza()
    {
        Velocidad += 0.1f;
        PorcentajeBloqueo += 0.05f;
    }
    public void ResetearValores()
    {
        Damage = 5f;
        Defensa = 2f;
        Velocidad = 5f;
        level = 1;
        Expactual = 0f;
        Exprequerida = 0f;
        PorcentajeBloqueo = 0f;
        PorcentajeCritico = 0f;

        Fuerza = 0;
        Inteligencia = 0;
        Destreza = 0;

        PuntosDisponibles = 0;

    }


}
