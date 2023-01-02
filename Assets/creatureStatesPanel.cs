using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class creatureStatesPanel : MonoBehaviour
{
    public TMP_Text health, experiance, magic, level, name;
    public Image image;
   
    private void Awake()
    {
        Stats.CreatureUIPanel += diplayUI;
    }

    private void diplayUI(Stats.creatureUIStats obj)
    {

      
        health.text = obj.health;
        experiance.text = obj.experiance;
        magic.text = obj.magic; 
        level.text = obj.level;
        name.text = obj.name;
        image.sprite = obj.image;
    }

   
    
    void Update()
    {
        
    }
}
