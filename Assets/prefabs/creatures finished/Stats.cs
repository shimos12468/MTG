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


    [SerializeField] private Transform castPoint;
    public Transform rotationofspell;
    public Spell[] AllSpells;
    public Spell[] PlayerSpells;
   



   
    
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
        if (Input.GetKeyDown("5") && creatureStats[3].Stat >= manacoast)
        {

            UsedSpell(PlayerSpells[0]);
           
            stat stat = new stat();
            stat = creatureStats[0];
            stat.Stat -= manacoast;
            creatureStats[0] = stat;
            setUI();

        }

        if (Input.GetKeyDown("4") && creatureStats[3].Stat >= Hmanacoast)
        {

            UsedSpell(PlayerSpells[1]);
           
            stat stat = new stat();
            stat = creatureStats[3];
            stat.Stat -= Hmanacoast;
            creatureStats[3] = stat;


            setUI();

        }
    }


    void UsedSpell(Spell spellToUse)
    {
       
        Spell spell = Instantiate(spellToUse, rotationofspell.transform.position, rotationofspell.rotation);
        spell.gameObject.GetComponent<Spell>().SendInfo(gameObject , creatureStats[6].Stat);
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
        magic.SetText(creatureStats[2].Stat.ToString() + " / " + creatureStats[2].baseStat);
        LEVEL.SetText(creature.level.ToString());
        Name.SetText(creature.name.ToString());
        experiance.SetText(creature.experiance.ToString() + " / " + creature.ExperiancelimitForUpgrade);
    }

    public void TakeDamage(float Damage)
    {

        stat stat2 = new stat();
        stat2 = creatureStats[0];
        stat2.Stat -= Damage;
        creatureStats[0]= stat2;
        if (stat2.Stat <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
