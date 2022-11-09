using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button male;
    public Button female;
    public Button StartGame;
    public Button ExitGame;
    public Image malecolor,femalecolor;
  
    public void ChanegMaleButtonColor(Image img)
    {
        img.color = Color.gray;
        femalecolor.color = Color.white;
        PlayerPrefs.SetInt("Type", 0);
    }
    public void ChanegFemaleButtonColor(Image img)
    {
        img.color = Color.gray;
        malecolor.color = Color.white;
        PlayerPrefs.SetInt("Type", 1);
    }
    public void Exit()
    {
        Application.Quit();
    }

}
