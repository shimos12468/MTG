using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

using static utilities;

public class Rune : MonoBehaviour 
{

   public abilities Type;
   public GameObject playerpoints;
   public GameObject overlay;
   public GameObject unlock;
   public TMP_Text RuneName;
   public bool unlocked = false;

     
   public GameObject creature;
   public List<int> percantage = new List<int>();

    rune rune1 = new rune();
   public  enum abilities
    {
        damage ,
        Defense ,
        mana ,
        speed,
        stamina,
        health,
        critDamage,
        regeneration
    }


    void Start()
    {
        percantage.Add(25);
      
    }

   public void check(rune rune)
    {
        rune1 = rune;

        Debug.Log(rune.name);
        Debug.Log(rune.Stat);
        Debug.Log(rune.level);
        Debug.Log(rune.price);
        Debug.Log(rune1.name);
        Debug.Log(rune1.Stat);
        Debug.Log(rune1.level);
        Debug.Log(rune1.price);
        RuneName.text = rune1.name.ToString();
        if (rune1.level > 0)
        {
            gameObject.transform.GetChild(6).gameObject.SetActive(false);
            for (int i = 0; i < rune1.level; i++)
                gameObject.transform.GetChild(i + 2).gameObject.SetActive(true);
        }



    }
    void Update()
    {
        
    }

    public void Unlock()
    {
        int playerPoints = int.Parse(playerpoints.GetComponent<TMPro.TMP_Text>().text);
        if (playerPoints - rune1.price >= 0)
        {
            int res = playerPoints - rune1.price;
            playerpoints.GetComponent<TMPro.TMP_Text>().text = res.ToString();
            
            overlay.gameObject.SetActive(false);
            unlocked = true;

            rune1.level += 1;
            rune1.price *=2;
            rune1.Stat = rune1.Stat + rune1.levelup[rune1.level-1];
            Debug.Log(rune1.Stat);
                
            for (int i = 0; i < rune1.level; i++)
                gameObject.transform.GetChild(i + 2).gameObject.SetActive(true);
            creature.GetComponent<Stats>().updateScript(rune1);
        }

    }

    public void sendrune()
    {
        unlock.GetComponent<runeSelection>().GetselectedRune(this);

    }
   
}
