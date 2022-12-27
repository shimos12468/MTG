using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static utilities;

public class UIutilities : MonoBehaviour, IUIClicked
{
    [SerializeField] bool state = false;
    [SerializeField] TMP_Text Name, Level, Button, price;
    [SerializeField] Image image;
    [SerializeField] GameObject shadow, statsList, statsPrefab;

    [SerializeField] List<GameObject> STATS = new List<GameObject>();
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
        for (int i = 0; i < number; i++)
            transform.GetChild(i).transform.gameObject.SetActive(state);

    }

    public void SetupUI(string name, string level, string price, Sprite icon, rune_Stats[] arr, string buttonText, RuneStates s)
    {



        if (s == RuneStates.LOCKED)
        {
            Name.text = name;
            Level.text ="Level: " + level; ;
            image.sprite = icon;
            Button.text = buttonText;
            this.price.text = price;
            shadow.gameObject.SetActive(false);
            for (int i = 0; i < arr.Length; i++)
            {
                GameObject prefab = Instantiate(statsPrefab, statsList.transform);
                prefab.transform.GetChild(0).GetComponent<TMP_Text>().text = arr[i].stats[0].name.ToString();
                prefab.transform.GetChild(1).GetComponent<TMP_Text>().text = "+" + arr[i].stats[0].baseStat.ToString();
                STATS.Add(prefab);
            }
        }
        if (s == RuneStates.UNLOCKED)
        {
            Name.text = name;
            Level.text = "Level: "+level;
            image.sprite = icon;
            Button.text = buttonText;
            this.price.text = price;
            shadow.gameObject.SetActive(false);

            for (int i = 0; i < arr.Length; i++)
            {

                STATS[i].transform.GetChild(0).GetComponent<TMP_Text>().text = arr[i].stats[int.Parse(level)].name.ToString();
                STATS[i].transform.GetChild(1).GetComponent<TMP_Text>().text = "+" + arr[i].stats[int.Parse(level)].baseStat.ToString();
            }
        }

        if (s == RuneStates.REACHED_MAXIMUM_LEVEL)
        {
            Button.text = "Maximum Level";
        }


    }
}
