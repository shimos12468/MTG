using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameLanguageManager : MonoBehaviour
{
    [SerializeField]
    List<TMP_Text> spanish ,english;
   

    public Toggle spanishToggle ,englishToggle;
   

   public void OnEnglishToggleChange()
    {

       
        if (englishToggle.isOn == true)
        {


            for(int i = 0; i < english.Count; i++)
            {
                spanish[i].gameObject.SetActive(false);
                english[i].gameObject.SetActive(true);
            }


            PlayerPrefs.SetInt("Language", 0);
        }


    }


    public void OnSpanishToggleChange()
    {

        if (spanishToggle.isOn == true)
        {


            for (int i = 0; i < spanish.Count; i++)
            {
                spanish[i].gameObject.SetActive(true);
                english[i].gameObject.SetActive(false);
            }

            PlayerPrefs.SetInt("Language", 1);

        }

    }
}
