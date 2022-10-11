using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroButton : MonoBehaviour
{
    private HeroInfo myHero;
    public Image heroIcon;


    public void PrintMyHero()
    {
        PrintHero.SharedInstance().PrintHeroMethod(myHero);
    }
    public void SetUpButton(HeroInfo heroInfo)
    {
        myHero = heroInfo;
        heroIcon.sprite = heroInfo.baseHero.heroIcon;
    }
}
