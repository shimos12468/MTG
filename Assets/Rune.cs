using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Rune : MonoBehaviour 
{

   public string name;
   
   public string Type = "";
   public GameObject playerpoints;
   public GameObject overlay;
    public GameObject unlock; 
   public bool unlocked = false;
   public int level = 0;
   public int price = 0;
   public int childindex = 3;
   public List<float> percantage = new List<float>() { 25 / 100, 35 / 100, 50 / 100 };
   
   public  enum abilities
    {
        damage ,
        Defense
    }


    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Unlock()
    {
        int playerPoints = int.Parse(playerpoints.GetComponent<TMPro.TMP_Text>().text);
        if (playerPoints - price >= 0)
        {
        int res = playerPoints - price;
        playerpoints.GetComponent<TMPro.TMP_Text>().text = res.ToString();
        unlocked = true;
        level = 1;
        overlay.gameObject.SetActive(false);
        transform.GetChild(childindex).gameObject.GetComponent<Image>().color = Color.white;
        price = price * 2;
        childindex++;
        // add to player level 1  percantage[level]
        // add new points to player script

        }

    }

    public void sendrune()
    {
        unlock.GetComponent<runeSelection>().GetselectedRune(this);

    }
    public void Upgrade()
    {

    }
}
