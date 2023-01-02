using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static utilities;

public class Stats : MonoBehaviour
{


    public struct creatureUIStats
    {
        public string health;
        public string magic;
        public string experiance;
        public string level;
        public string name;
        public Sprite image;

    }

  
    creatureUIStats creatureUI;
    public static Action<creatureUIStats> CreatureUIPanel;
    public static Action<Rune, bool> CreatureRunesPanel;
    public List<Rune> runesOptained;
    public creature creature = new creature();


    public List<stat> creatureStats = new List<stat>();

    public int NumOfEvolve;
    public int[] evolveLevels;
    public int evolveStages = 0;

   
    void Start()
    {
       

        setUI();

        evolveLevels = new int[NumOfEvolve];
        for (int i = 0; i < NumOfEvolve; i++)
        {
            evolveLevels[i] = i * 2 + 3;
        }
    }

    public void setUI()
    {
        creatureUI.health = creatureStats[0].Stat + " / " + creatureStats[0].baseStat.ToString();
        creatureUI.magic = creatureStats[3].Stat.ToString() + " / " + creatureStats[3].baseStat;
        creatureUI.name = creature.name;
        creatureUI.level = creature.level.ToString();
        creatureUI.experiance = creature.experiance.ToString() + " / " + creature.ExperiancelimitForUpgrade;
        creatureUI.image = creature.Icon;
        CreatureUIPanel?.Invoke(creatureUI);
    }

    public void BuyRune(Rune rune)
    {
        creature.skillPoints -= rune.priceForUnlock;
        runesOptained.Add(rune);

        
        for (int i = 0; i < creatureStats.Count; i++)
        {
            for (int j = 0; j < rune.stats.Length; j++)
            {
                if (creatureStats[i].name == rune.stats[j].stats[rune.level].name)
                {
                    stat stat = creatureStats[i];
                    stat.Stat += rune.stats[j].stats[rune.level].Stat;
                    stat.baseStat += rune.stats[j].stats[rune.level].baseStat;
                    creatureStats[i] = stat;
                    break;
                }
            }
        }

       
        CreatureRunesPanel?.Invoke(rune, true);
    }
    public void UpgradeRune(Rune rune)
    {
        creature.skillPoints -= rune.priceForUpgrade;


        for (int i = 0; i < creatureStats.Count; i++)
        {
            for (int j = 0; j < rune.stats.Length; j++)
            {
                if (creatureStats[i].name == rune.stats[j].stats[rune.level].name)
                {
                    stat stat = creatureStats[i];
                    stat.Stat += rune.stats[j].stats[rune.level].Stat;
                    stat.baseStat += rune.stats[j].stats[rune.level].baseStat;
                    creatureStats[i] = stat;

                }
            }
        }

        for (int i = 0; i < runesOptained.Count; i++)
        {
            if (runesOptained[i].name == rune.name)
            {
                runesOptained[i] = rune;
            }
        }

        CreatureRunesPanel?.Invoke(rune, false);
    }

    private void Update()
    {

        if (creature.experiance >= creature.ExperiancelimitForUpgrade)
        {
            creature.level++;
            creature.ExperiancelimitForUpgrade += 2;
        }

        if (evolveStages < evolveLevels.Length && creature.level >= evolveLevels[evolveStages])
        {

            EvolveCreature();
            evolveStages++;
        }


    }


    private void EvolveCreature()
    {

        if (creature.UpgradeCreature != null)
        {

            Vector3 position = transform.position;
            GameObject newcreature = Instantiate(creature.UpgradeCreature);
            newcreature.GetComponent<Stats>().creatureStats = creatureStats;


            newcreature.transform.parent = null;
            newcreature.transform.position = position;

            for (int i = 0; i < SWIP_creatures.Instance.creatures.Count; i++)
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

    public void TakeExp(float exp, int points, int coins)
    {

        creature.experiance += exp;
        creature.skillPoints += points;
        setUI();
    }


    // I have to
}
