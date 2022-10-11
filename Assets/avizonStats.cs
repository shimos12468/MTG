using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class avizonStats : Creatures_Stats
{

    
    void Start()
    {
        name = "Avizon";
        type1 = Types.Bug.ToString();
        type2 = Types.Wind.ToString();
        baseHealth = 30;
        Magic = 40;
        baseMagic = 40;
        healthMultiplier = 0.2f;
        Expactual = 0;
        Exprequerida = 10;
        Health = baseHealth;
        health = GameObject.FindGameObjectWithTag("Health").GetComponent<TMP_Text>();
        magic = GameObject.FindGameObjectWithTag("Magic").GetComponent<TMP_Text>();
        experiance = GameObject.FindGameObjectWithTag("experiance").GetComponent<TMP_Text>();
        LEVEL = GameObject.FindGameObjectWithTag("Level").GetComponent<TMP_Text>();
        Name = GameObject.FindGameObjectWithTag("name").GetComponent<TMP_Text>();
        img = GameObject.FindGameObjectWithTag("HeroIcon").GetComponent<Image>();

        setUI();

    }

    public void setUI()
    {
        img.sprite = heroIcon;
        health.text = baseHealth.ToString() + " / " + Health;
        magic.SetText(Magic.ToString() + " / " + baseMagic);
        LEVEL.SetText(level.ToString());
        Name.SetText(name.ToString());
        experiance.SetText(Expactual.ToString() + " / " + Exprequerida);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    
}
