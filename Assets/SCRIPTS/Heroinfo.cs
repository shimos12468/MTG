using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Rarity{Common,Rare,Epic,Legendary }
public enum HeroClass { Ranger ,Warrior,Mage }

[Serializable]
public struct HeroType
{
    
    public string name;
    public int baseHealth;
    public float healthMultiplier;
    public Sprite heroImage;
    public Rarity rarity;
    public HeroClass type;
    public Sprite heroIcon;
}

public class HeroInfo 
{
    public HeroType baseHero;
    public int health;
    public int experience;
    public int level;
    public HeroInfo(HeroType _baseHero)
    {
        baseHero = _baseHero;
    }

    public void AddExperience(int value)
    {
        experience += value;
    }
    //healthmultiplier = 0.02 makes 2 percent health increase per level
    public int CalculateHealth()
    {
        return Convert.ToInt32( baseHero.baseHealth * Mathf.Pow(baseHero.healthMultiplier+1, level));
    }
    public void LevelUp()
    {
        level++;
    }
}
