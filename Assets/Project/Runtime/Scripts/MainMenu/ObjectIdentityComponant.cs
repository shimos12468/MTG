using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectIdentityComponant : MonoBehaviour
{
    private GameObject Object { get; set; }
    private UIManager M;

    private void Awake()
    {
         M = FindObjectOfType<UIManager>();

    }

    public void Onclicked()
    {

        UIManager M = FindObjectOfType<UIManager>();


        if (Object.tag == "creature")
        {

            Debug.Log(Object.tag);
            UIManager.nextState = UIManager.NextState(UIManager.currentState, UIManager.actions.clickCreature);
            UIManager.currentState = M.PerformActions(UIManager.currentState, UIManager.nextState,Object);


        }
        else
        {
            Debug.Log(  UIManager.currentState);
            UIManager.nextState = UIManager.NextState(UIManager.currentState, UIManager.actions.clickCharacter);
            UIManager.currentState = M.PerformActions(UIManager.currentState, UIManager.nextState, Object);
        }

    }

    public void SetObject(GameObject obj)
    {
        this.Object = obj;
    }
}
