using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class queenflora : Creatures_Stats
{
    // Start is called before the first frame update
    void Start()
    {
       
        
       
        health = GameObject.FindGameObjectWithTag("Health").GetComponent<TMP_Text>();
        magic = GameObject.FindGameObjectWithTag("Magic").GetComponent<TMP_Text>();
        experiance = GameObject.FindGameObjectWithTag("experiance").GetComponent<TMP_Text>();
        LEVEL = GameObject.FindGameObjectWithTag("Level").GetComponent<TMP_Text>();
        Name = GameObject.FindGameObjectWithTag("name").GetComponent<TMP_Text>();
        img = GameObject.FindGameObjectWithTag("HeroIcon").GetComponent<Image>();
        setUI();

    }

    // Update is called once per frame
    void Update()
    {
        if (Expactual >= Exprequerida)
        {
            levelUP();
        }

       
    }

    private void levelUP()
    {
        if (level < evolutionlevel)
        {
            Debug.Log("level 1");
            level += 1;
            Health += 15;
            baseHealth += baseHealth / 2;
            Damage += 10;
            Exprequerida += 20;
            Magic += 10;
            setUI();
        }
        if (level == evolutionlevel)
        {
            Debug.Log("level 2");

            GameObject player= GameObject.FindGameObjectWithTag("Player");
            int bone= player.GetComponent<Inventory_system>().bonecounter;
            int crystal = player.GetComponent<Inventory_system>().crystalcounter;
            bone -= 2;
            crystal -= 1;
            
                player.GetComponent<Inventory_system>().bonecounter = bone;
                player.GetComponent<Inventory_system>().crystalcounter=crystal;

                evelotion();

        }
        

    }

    public void evelotion()
    {


        GameObject evolve = GameObject.FindGameObjectWithTag("evolve");
        evolve.GetComponent<evolve>().evolve_creature(gameObject, evolvecreature ,level ,Health ,Expactual,Exprequerida ,Magic ,baseHealth ,Damage);

       
                
    }
    public void setUI()
    {
        img.sprite = heroIcon;
        health.text = Health + " / " +  baseHealth.ToString();
        magic.SetText(Magic.ToString() + " / " + baseMagic);
        LEVEL.SetText(level.ToString());
        Name.SetText(name.ToString());
        experiance.SetText(Expactual.ToString() + " / " + Exprequerida);
    }

    

}
