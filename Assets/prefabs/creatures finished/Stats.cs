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
    public Sprite Icon;
    public float experiance;
    public int points;
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




    }

    public void setUI()
    {

        
        img.sprite = creature.Icon;
        health.text = creatureStats[0].Stat + " / " + creatureStats[0].baseStat.ToString();
        magic.SetText(creatureStats[2].Stat.ToString() + " / " + creatureStats[2].baseStat);
        LEVEL.SetText(creature.level.ToString());
        Name.SetText(creature.name.ToString());
        experiance.SetText(creature.experiance.ToString() + " / " + creature.ExperiancelimitForUpgrade);
    }
}
