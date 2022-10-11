using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class beckend : Creatures_Stats
{
    // Start is called before the first frame update
    void Start()
    {
        name = "Beckend";
        type1 = Types.Water.ToString();
        type2 = Types.Dark.ToString();
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
        health.text =  baseHealth.ToString() + " / "+Health;
        magic.SetText(Magic.ToString()+" / "+baseMagic);
        LEVEL.SetText(level.ToString());
        Name.SetText(name.ToString());
        experiance.SetText(Expactual.ToString()+" / "+ Exprequerida);
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(type1);
        Debug.Log(type2);
    }
}
