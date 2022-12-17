using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject ObjectsStatsScreen ,OnPlayUI  , menuScreen,chracterScreen ,creatureScreen;
    void Start()
    {
        menu.Object += SetMenuActivity;
        OnPlayUI.SetActive(true);
    }

    private void SetMenuActivity(GameObject obj)
    {
        menuScreen.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
