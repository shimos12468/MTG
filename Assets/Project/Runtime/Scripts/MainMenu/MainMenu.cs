using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;


public class MainMenu : MonoBehaviour
{
    public Button male;
    public Button female;
    public Button StartGame;
    public Button ExitGame;
    public Image malecolor,femalecolor;

    public List<GameObject> subMenus = new List<GameObject>();

    private MenuInputAction menuInputActions;
    private InputAction Escape;

    private void Awake()
    {
        menuInputActions = new MenuInputAction();

    }

    private void OnEnable()
    {
        Escape = menuInputActions.Menu.Escape;
        Escape.performed += escape;
        Escape.Enable();
    }

    private void escape(InputAction.CallbackContext obj)
    {
        for(int i = 0; i < subMenus.Count; i++)
        {
             bool m = subMenus[i].activeInHierarchy == true ? false:false;
             subMenus[i].SetActive(m);
        }
       
    }

    private void OnDisable()
    {
        Escape.Disable();
    }

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
