using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class HeroManager : MonoBehaviour
{
    public List<HeroType> heroTypes;
    public List<HeroInfo> myHeroes = new List<HeroInfo>();
    public string testname;
    public HeroButton heroButtonPrefab;
    public Transform heroContainer;

    public void AddHeroToCollection(HeroType newHeroType)
    {
        HeroInfo newHero = new HeroInfo(newHeroType);
        myHeroes.Add(newHero);
        HeroButton temp = Instantiate(heroButtonPrefab, heroContainer);
        temp.SetUpButton(newHero);
    }
    public void testFunction()
    {

        HeroType temp = heroTypes.FirstOrDefault(n => n.name == testname);
        AddHeroToCollection(temp);
        
    }



}
