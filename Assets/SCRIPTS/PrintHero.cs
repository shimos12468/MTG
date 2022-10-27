using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class PrintHero : MonoBehaviour
{

    public TextMeshProUGUI heroNameUI;
    public TextMeshProUGUI healthTextUI;
    public Image heroImageUI;
    private HeroInfo heroOnScreen;


    private static PrintHero instance;
    public static PrintHero SharedInstance() => instance ;

   private void Awake()
    {
        instance = this;
    }






public void PrintHeroMethod(HeroInfo input)
    {
        heroNameUI.text = input.baseHero.name;
        healthTextUI.text = Convert.ToString(input.CalculateHealth());
        heroImageUI.sprite = input.baseHero.heroImage;
        heroOnScreen = input;

    }
    public void TestLevelUp()
    {
        heroOnScreen.LevelUp();
        PrintHeroMethod(heroOnScreen);
    }
   
}
