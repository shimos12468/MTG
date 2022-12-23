using Codice.Client.BaseCommands.BranchExplorer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UiBehavior : MonoBehaviour
{
    
    private EnviromentSceneInput inputActions;
    private InputAction Escape;

    public static  Action<List<GameObject> ,GameObject>menuAction;

    public GameObject objectsStatsScreens;
    public GameObject OnplayUI;

    List<GameObject> SpawnedCreatures = new List<GameObject>();
    public bool state = false;


    private void Awake()
    {
        
        inputActions = new EnviromentSceneInput();
        Escape = inputActions.GeneralInputs.Escape;
        Escape.started += escape;
        Escape.Enable();
    }
    private void escape(InputAction.CallbackContext obj)
    {


        if (transform.GetComponent<character_controler>().isFoucsed)
        {
                List<GameObject> CreaturesAndCharacterInTheSceen = GetSpwanedcreatures();
                menuAction?.Invoke(CreaturesAndCharacterInTheSceen, gameObject);
               
        }
    
    }

    public List<GameObject> GetSpwanedcreatures()
    {
        bool flag = transform.GetComponent<creatuers_spawn>() ? true : false;
        flag = transform.GetComponent<creatuers_spawn>().GetSpawnedCreatures().Count>0 ?true:false;
        SpawnedCreatures = flag ? transform.GetComponent<creatuers_spawn>().GetSpawnedCreatures() : new List<GameObject>();
       
        return SpawnedCreatures;
    }
    
}
