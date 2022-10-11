using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Creature : MonoBehaviour
{
    PERSONAJESTATS stats;
    int level;
    public int health;
    public int experience;
    public Creature(PERSONAJESTATS pstats, int plevel)
    {
        stats = pstats;

        level = plevel;
    }



    public void AddExperience(int value)
    {
        experience += value;
    }
    //healthmultiplier = 0.02 makes 2 percent health increase per level
    public int CalculateHealth()
    {
        return Convert.ToInt32(stats.baseHealth * Mathf.Pow(stats.healthMultiplier + 1, level));
    }
    public void LevelUp()
    {
        level++;
    }
}


