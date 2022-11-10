using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum Raritys { Common, Uncommon, Rare, Epic, Legendary }
public enum statType { Health, crit, regen, mana, stamina, defence ,damage, speed}
public enum Types { Fire, Dark, Light, Metal, Water, Nature, Wind, Poison, Melee, Bug, Rock, Electric }

[System.Serializable]
public struct stat
{
    public statType name;
    public float Stat;
    public float baseStat;
}

 
[System.Serializable]
public struct item
{
    public string name;
    public List<itemStats> stats;
    public int price;
    public Sprite Icon;
    public string Discription;
    public bool ownership;
}


[System.Serializable]
public struct itemStats
{
    public statType name;
    public float stat;
}


[System.Serializable]
public struct rune
{
    public statType name;
    public float Stat;
    public int level;
    public int price;
    public int[] levelup;
}

[System.Serializable]
public struct creature
{
    public string name;
    public int Points;
    public int coins;
    public Sprite Icon;
    public float experiance;
    public float ExperiancelimitForUpgrade;
    public int level;
    public Raritys raritys;
    public Types Ftype;
    public Types Stype;
    public GameObject UpgradeCreature;
}
public class Stats : MonoBehaviour
{

    
    

    public creature creature = new creature();
    public List<stat> creatureStats= new List<stat>();
    public List<rune> runes= new List<rune>();
    public List<item> items = new List<item>();
    float manacoast = 10;
    float Hmanacoast = 10;
    TMP_Text health;
    TMP_Text magic;
    TMP_Text experiance;
    TMP_Text Name;
    TMP_Text LEVEL;
    Image img;

    
    public Dictionary<string, float[]> StatsDictionary = new Dictionary<string, float[]>();

    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Health").GetComponent<TMP_Text>();
        magic = GameObject.FindGameObjectWithTag("Magic").GetComponent<TMP_Text>();
        experiance = GameObject.FindGameObjectWithTag("experiance").GetComponent<TMP_Text>();
        LEVEL = GameObject.FindGameObjectWithTag("Level").GetComponent<TMP_Text>();
        Name = GameObject.FindGameObjectWithTag("name").GetComponent<TMP_Text>();
        img = GameObject.FindGameObjectWithTag("HeroIcon").GetComponent<Image>();

        for(int i = 0; i < creatureStats.Count; i++)
        {
           float[] m = new float[2]{ creatureStats[i].Stat, creatureStats[i].baseStat };
           StatsDictionary.Add(creatureStats[i].name.ToString(),m);
        }
       

        setUI();
    }


    private void Update()
    {

        if (creature.experiance >= creature.ExperiancelimitForUpgrade)
        {
            creature.level++;
            creature.ExperiancelimitForUpgrade += 2;
        }

        if (creature.level >= 2)
        {
             
            EvolveCreature();
        }

      
    }


    
    public void updateScript(rune rune)
    {

        
        for (int i = 0; i < runes.Count; i++)
        {
            if (rune.name == runes[i].name)
            {
                runes[i] = rune;
                break;

            }
        }

        for (int i = 0; i < runes.Count; i++)
        {
            if (rune.name == creatureStats[i].name)
            {
                stat stat = new stat();
                stat = creatureStats[i];
                stat.Stat+= rune.Stat;
                creatureStats[i] = stat;
                break;

            }
        }
        setUI();
    }

    private void EvolveCreature()
    {
        Debug.Log("Evolving");
        if (creature.UpgradeCreature != null)
        {

        Vector3 position = transform.position;
        GameObject newcreature = Instantiate(creature.UpgradeCreature);
        newcreature.GetComponent<Stats>().creatureStats = creatureStats;
        newcreature.GetComponent<Stats>().runes = runes;
        newcreature.GetComponent<Stats>().items = items;
        newcreature.transform.parent = null;
        newcreature.transform.position = position;

        for(int i = 0; i < SWIP_creatures.Instance.creatures.Count; i++)
            {
                if (SWIP_creatures.Instance.creatures[i].GetComponent<Stats>().creature.name == creature.name)
                {
                    SWIP_creatures.Instance.creatures[i] = newcreature;
                }
           }

            for (int i = 0; i < SWIP_creatures.Instance.CreaturesIMG.Count; i++)
            {
                if (SWIP_creatures.Instance.CreaturesIMG[i].name == creature.Icon.name)
                {
                    SWIP_creatures.Instance.CreaturesIMG[i] = newcreature.GetComponent<Stats>().creature.Icon;
                }
            }
            Destroy(this.gameObject);
        }
    }

    public void UpdateStats(item newItem ,char c)
    {

        if (c == 'A')
        {
        Debug.Log("updating stats...");
        for(int i = 0; i < creatureStats.Count; i++)
        {
            for(int j = 0; j < newItem.stats.Count; j++)
            {
                if (newItem.stats[j].name.ToString() == creatureStats[i].name.ToString())
                {
                    stat stat2 = new stat();
                    stat2 = creatureStats[i];
                    stat2.Stat += newItem.stats[j].stat;
                    stat2.baseStat += newItem.stats[j].stat;
                    creatureStats[i] = stat2;

                    Debug.Log("found A stat NICE");
                }
            }
        }


        }


        if (c == 'R')
        {
            Debug.Log("updating stats...");
            for (int i = 0; i < creatureStats.Count; i++)
            {
                for (int j = 0; j < newItem.stats.Count; j++)
                {
                    if (newItem.stats[j].name.ToString() == creatureStats[i].name.ToString())
                    {
                        stat stat2 = new stat();
                        stat2 = creatureStats[i];
                        stat2.Stat -= newItem.stats[j].stat;
                        if (stat2.Stat < 0) stat2.Stat = 0;
                        stat2.baseStat -= newItem.stats[j].stat;
                        creatureStats[i] = stat2;

                        Debug.Log("found A stat NICE");
                    }
                }
            }


        }

        setUI();
    }

    public void setUI()
    {

        
        img.sprite = creature.Icon;
        health.text = creatureStats[0].Stat + " / " + creatureStats[0].baseStat.ToString();
        magic.SetText(creatureStats[3].Stat.ToString() + " / " + creatureStats[3].baseStat);
        LEVEL.SetText(creature.level.ToString());
        Name.SetText(creature.name.ToString());
        experiance.SetText(creature.experiance.ToString() + " / " + creature.ExperiancelimitForUpgrade);
    }

  

    public void TakeExp(float exp ,int points ,int coins)
    {
        creature.experiance += exp;
        creature.Points += points;
        creature.coins += coins;
    }
}
