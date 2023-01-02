using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using static utilities;
public class CreatureMenuScreen : MonoBehaviour
{

    [SerializeField] Image background;
    [SerializeField] TMP_Text creatureName;


    public GameObject runePrefab;
    public RectTransform map;
    List<GameObject> runesgameObject = new List<GameObject>();
    List<Rune>runes = new List<Rune>();
    public lifeEssence lifeEssence;
    public cursedSwamp cursedSwamp;

    private Stats creatureStats;
    private void Awake()
    {
        runes.Add(lifeEssence);
        runes.Add(cursedSwamp);

        DisplayRunes();
    }


    public void RuneClicked(int i)
    {

        Debug.Log("hello   " + i);
        int points = creatureStats.creature.skillPoints;
        if (points >= runes[i].priceForUpgrade && creatureStats.runesOptained.Contains(runes[i]) && runes[i].level < 3)
        {

            creatureStats.UpgradeRune(runes[i]);
            creatureStats.setUI();
            runes[i].level += 1;
            if (runes[i].level == 3)
            {
                runes[i].reachedMaximum= true;

            }
            changeRune(i);

        }
       
        if (points >= runes[i].priceForUnlock && !creatureStats.runesOptained.Contains(runes[i]))
        {
            creatureStats.BuyRune(runes[i]);
            creatureStats.setUI();
            runes[i].level += 1;
            runes[i].Unlocked = true;
            changeRune(i);

        }
    }

    private void changeRune(int i)
    {


        if (runes[i].level == 3)
        {
            runesgameObject[i].GetComponent<UIutilities>().SetupUI(runes[i].name,
              runes[i].level.ToString()
              , runes[i].priceForUpgrade.ToString()
              , runes[i].icons[runes[i].level < 3 ? runes[i].level : 2]
              , runes[i].stats, "Upgreade", RuneStates.REACHED_MAXIMUM_LEVEL);
        }
        else
        {
            runesgameObject[i].GetComponent<UIutilities>().SetupUI(runes[i].name,
              runes[i].level.ToString()
              , runes[i].priceForUpgrade.ToString()
              , runes[i].icons[runes[i].level < 3 ? runes[i].level : 2]
              , runes[i].stats, "Upgreade", RuneStates.UNLOCKED);
        }
    }

    public  void GetObject(GameObject obj)
    {
        creatureName.text = obj.GetComponent<Stats>().creature.name;
        creatureStats = obj.GetComponent<Stats>();
        if (obj.tag == "Creature")
        {
            background.enabled = true;
            for (int i = 0; i < transform.childCount; i++)
                transform.GetChild(i).gameObject.SetActive(true);
        }


      
    }
    void DisplayRunes()
    {

        int number = runes.Count;
        float width = map.rect.width;
        float height = map.rect.height;

        GameObject prefab = Instantiate(runePrefab, map);
        Vector3 position=  Vector3.zero;
        prefab.transform.localPosition =position;

        runesgameObject.Add(prefab);
        Vector3[] positions = {new Vector3(0, 0.9f, 0) ,new Vector3(2,0,0) ,new Vector3(2,0.9f,0), new Vector3(0, -0.9f, 0), new Vector3(-2, 0, 0), new Vector3(-2, -0.9f, 0) , new Vector3(2, -0.9f, 0), new Vector3(-2, 0.9f, 0) };

        int constant = 50;
        for (int i = 1; i <number; i++)
        {
            int distance = i * constant+155;

            if(-width/2< (positions[i % positions.Length] * distance).x && (positions[i % positions.Length] * distance).x < width / 2)
            {
                if (-height / 2 < (positions[i % positions.Length] * distance).y && (positions[i % positions.Length] * distance).y < height / 2)
                {
                    GameObject objec = Instantiate(runePrefab, map);
                    
                    objec.transform.localPosition = positions[i % positions.Length] * distance;
                    objec.GetComponent<UIutilities>().index = i;
                    runesgameObject.Add(objec);
                }

            }
             

        }


        for(int i = 0; i < runes.Count; i++)
        {
            runesgameObject[i].GetComponent<UIutilities>().index= i;
            runesgameObject[i].GetComponent<UIutilities>().SetupUI(runes[i].name.ToString() ,
                runes[i].level.ToString()
                , runes[i].priceForUnlock.ToString()
                , runes[i].icons[runes[i].level]
                , runes[i].stats ,"Unlock" , RuneStates.LOCKED);

        }

        



    }

    
    

}
