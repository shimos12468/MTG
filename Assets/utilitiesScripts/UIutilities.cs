using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static utilities;

public class UIutilities : MonoBehaviour ,IUIClicked
{
    [SerializeField] bool state = false;
    [SerializeField] TMP_Text Name, Level;
    [SerializeField] Image image; 
    public int index;
    CreatureMenuScreen screen;
    public void Onclicked()
    {
        screen = GameObject.FindObjectOfType<CreatureMenuScreen>();
        screen.RuneClicked(index);
    }

    public void changeUIState(int number)
    {
        state = !state;
        for (int i = 0;i<number;i++)
        transform.GetChild(i).transform.gameObject.SetActive(state);
        
    }

    public void SetupUI(string name ,string level ,string price ,Sprite icon , stat[] arr )
    {
        Name.text = name;
        Level.text = level;
        image.sprite = icon;


    }
}
