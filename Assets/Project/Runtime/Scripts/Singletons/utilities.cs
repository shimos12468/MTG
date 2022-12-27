using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class utilities : MonoBehaviour
{
    public struct Settings
    {
        public float musicVolume;
        public float effectsVolume;
        public float mouseSensitivity;
    }


    public enum Raritys { Common, Uncommon, Rare, Epic, Legendary }
    public enum statType { Health, crit, regen, mana, stamina, defence, damage, speed }
    public enum Types { Fire, Dark, Light, Metal, Water, Nature, Wind, Poison, Melee, Bug, Rock, Electric }
    public enum Effect {Teleport ,Capture ,Walk}

    [System.Serializable]
    public struct stat
    {
        public statType name;
        public float Stat;
        public float baseStat;
    }

    [System.Serializable]
    public struct rune_Stats
    {
        public List<stat> stats;
    }

    public interface Iboot
    {
        public void OnWalk();
        public void OnStop();
    }



    [System.Serializable]
    public struct item
    {
        public string name;
        public List<itemStats> stats;
        public int price;
        public Sprite Icon;
        public string Discription;
        public bool ownership;
    }


    [System.Serializable]
    public struct itemStats
    {
        public statType name;
        public float stat;
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
        public int skillPoints;
        public Sprite Icon;
        public float experiance;
        public float ExperiancelimitForUpgrade;
        public int level;
        public Raritys raritys;
        public Types Ftype;
        public Types Stype;
        public GameObject UpgradeCreature;
    }


    [System.Serializable]
    public class Rune

    {
        public string name;
        public int level;
        public int priceForUnlock;
        public int priceForUpgrade;
        public bool Unlocked;
        public bool reachedMaximum;
       
        public Sprite[] icons = new Sprite[3];
        public rune_Stats[] stats; 


        public virtual void excute()
        {

        }

    }
    public enum RuneStates
    {
        UNLOCKED,
        LOCKED,
        REACHED_MAXIMUM_LEVEL ,
        UPGRADE
    }

    [System.Serializable]
    public class lifeEssence : Rune
    {

        public override void excute()
        {
            base.excute();
        }
    }
    [System.Serializable]
    public class eternalRage : Rune
    {

        public override void excute()
        {
            base.excute();
        }
    }

    [System.Serializable]
    public class cursedSwamp : Rune
    {

        public override void excute()
        {
            base.excute();
        }
    }

}

public interface IUIClicked
{
    public void Onclicked();
}
