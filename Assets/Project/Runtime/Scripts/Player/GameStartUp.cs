using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameStartUp : MonoBehaviour
{

    public static GameStartUp Instance;
    [SerializeField]
    public GameObject player;
    [SerializeField]
    GameObject femaleperfab;
    [SerializeField]
    GameObject maleprefab;
    [SerializeField]
     
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
            player = Instantiate(femaleperfab);
            
        }

        if (PlayerPrefs.GetInt("Type") == 0)
        {
            player = Instantiate(maleprefab);
            
        }

    }

    
    

   
}
