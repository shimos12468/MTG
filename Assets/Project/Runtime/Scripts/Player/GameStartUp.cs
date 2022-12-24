using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameStartUp : MonoBehaviour
{

    public static GameStartUp Instance;
   
    [SerializeField]
    GameObject femaleperfab;
    [SerializeField]
    GameObject maleprefab;
    [SerializeField]

    GameObject runesTextS , runesTextE, teamTextS , teamTextE  ,MainmenuS, MainmenuE;
    void Start()
    {
        if (Instance == null)
        {
            Instance=this;
        }
        else
        {
            Destroy(this);
        }

        float musicvolume = PlayerPrefs.HasKey("musicVolume") == true ? PlayerPrefs.GetFloat("musicVolume") : -1f;
        Camera.main.GetComponent<AudioSource>().volume = musicvolume!=-1?musicvolume:1;

        if (PlayerPrefs.GetInt("Type")==1)
        {
             Instantiate(femaleperfab);
            
        }

        if (PlayerPrefs.GetInt("Type") == 0)
        {
            Instantiate(maleprefab);
            
        }

        
       SetGameLanguage(PlayerPrefs.GetInt("Language"));
        

    }


    public void SetGameLanguage(int i )
    {
        if (i == 0)
        {
            teamTextS.SetActive(false); 
            teamTextE.SetActive(true);
            runesTextE.SetActive(true);
            runesTextS.SetActive(false);
            MainmenuS.SetActive(false);
            MainmenuE.SetActive(true);
        }
        else
        {
            teamTextS.SetActive(true);
            teamTextE.SetActive(false);
            runesTextE.SetActive(false);
            runesTextS.SetActive(true);
            MainmenuS.SetActive(true);
            MainmenuE.SetActive(false);
        }
    }
    
    

   
}
