using Codice.Client.BaseCommands;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
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
    //Actions
    public static Action<creatureUIStats> CreatureUIPanel;
    public static Action<Rune, bool> UpdateRuneList;
    public static Action<List<Rune>> SetRunesList;
    public static Action<int, bool> ScrollAction;
    public static Action<int ,float> CastRune;
    
    public List<Rune> runesOptained;
    public creature creature = new creature();
    //parameters
    private int counter = 0;
    private int counter2 = 0;
    private int Max = 1, Min = 1;
    private int selectedIndex = 0;

    public List<stat> creatureStats = new List<stat>();

    public int NumOfEvolve;
    public int[] evolveLevels;
    public int evolveStages = 0;
    //Input System
    private EnviromentSceneInput inputActions;
    private InputAction Cast;
    private void Awake()
    {
        inputActions = new EnviromentSceneInput();
        Cast = inputActions.GeneralInputs.CastRuneEffect;
        Cast.started += RuneCast;
        Cast.Enable();
    }
    private void RuneCast(InputAction.CallbackContext obj)
    {
        CastRune?.Invoke(selectedIndex, runesOptained[selectedIndex].cooldown);
         
    }
    private void OnEnable()
    {
        SetRunesList?.Invoke(runesOptained);
    }
    void Start()
    {
       

        setUI();
        SetRunesList?.Invoke(runesOptained);
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


        SetRunesList?.Invoke(runesOptained);
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

        SetRunesList?.Invoke(runesOptained);
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
        scroll();

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

    public void scroll()
    {

        counter = Input.GetAxis("Mouse ScrollWheel") > 0f ? 1 : 0;
        counter2 = Input.GetAxis("Mouse ScrollWheel") < 0f ? 1 : 0;
        Debug.Log(selectedIndex);
        if (counter2 >= Max)
        {

            Debug.Log("inscrease" + runesOptained.Count);
            if (selectedIndex + 1 < runesOptained.Count)
            {
                Debug.Log("inscrease part 2");
                
                ScrollAction?.Invoke(selectedIndex ,true);
                selectedIndex += 1;
            }
            counter = 0;
        }
        if (counter >= Min)
        {
            Debug.Log("decrease");
            if (selectedIndex - 1 >= 0)
            {
                Debug.Log("decrease part 2");
              
                ScrollAction?.Invoke(selectedIndex, false);
                selectedIndex -= 1;
            }
            counter2 = 0;
        }
    }
    
}
