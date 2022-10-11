using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureManager : MonoBehaviour
{
    //public List<HeroType> heroTypes;
    public List<PERSONAJESTATS> myCreatures = new List<PERSONAJESTATS>();
   /* public void AddHeroToCollection(HeroType newHeroType)
    {
        HeroInfo newHero = new HeroInfo(newHeroType);
        myHeroes.Add(newHero);
        HeroButton temp = Instantiate(heroButtonPrefab, heroContainer);
        temp.SetUpButton(newHero);
    }*/
}
