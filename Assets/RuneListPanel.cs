using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static utilities;
using static UnityEditor.Progress;

public class RuneListPanel : MonoBehaviour
{
    [SerializeField] GameObject runeprefab;
    [SerializeField] Color defultlevel, upgradelevel;
    private List<GameObject> runesGameObjects = new List<GameObject>();
    private List<Rune> runes = new List<Rune>();
    
    private List<int>Cooldownkeys= new List<int>();
    private List<float>CoolDownTime= new List<float>();
    private void Awake()
    {
        Stats.UpdateRuneList += updateList;
        Stats.ScrollAction += scroll;
        Stats.CastRune += SetTimer;
        Stats.SetRunesList += SetRunes;
    }

    private void SetRunes(List<Rune> obj)
    {
        runes.Clear();
        

        for(int i = 0; i < runesGameObjects.Count; i++)
        {
            Destroy(runesGameObjects[i]);
        }
        runesGameObjects.Clear();
        for (int i = 0; i < obj.Count; i++)
        {
            runes.Add(obj[i]);

            GameObject prefab = Instantiate(runeprefab, transform);
            prefab.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = obj[i].icons[obj[i].level];
            prefab.transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>().text = obj[i].name;
            prefab.transform.GetChild(0).GetChild(3).GetComponent<TMP_Text>().text = obj[i].cooldown.ToString();
            prefab.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>().color = defultlevel;
            prefab.transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<Image>().color = defultlevel;
            prefab.transform.GetChild(0).GetChild(2).GetChild(2).GetComponent<Image>().color = defultlevel;
            prefab.transform.GetChild(0).GetChild(2).GetChild(obj[i].level).GetComponent<Image>().color = upgradelevel;

            runesGameObjects.Add(prefab);
        }
    }

    private void SetTimer(int index, float time)
    {
        Cooldownkeys.Add(index);
        CoolDownTime.Add(time);
    }

    private void scroll(int index, bool operation)
    {
        if (operation)
        {
            Debug.Log("inscrease part 2");
            runesGameObjects[index].transform.GetChild(1).gameObject.SetActive(false);
            index++;
            runesGameObjects[index].transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("decrease part 2");
            runesGameObjects[index].transform.GetChild(1).gameObject.SetActive(false);
            index--;
            runesGameObjects[index].transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    private void updateList(Rune obj, bool NewRune)
    {
        if (NewRune)
        {
            runes.Add(obj);

            GameObject prefab = Instantiate(runeprefab, transform);
            prefab.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = obj.icons[obj.level];
            prefab.transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>().text = obj.name;
            prefab.transform.GetChild(0).GetChild(3).GetComponent<TMP_Text>().text = obj.cooldown.ToString();
            prefab.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>().color = defultlevel;
            prefab.transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<Image>().color = defultlevel;
            prefab.transform.GetChild(0).GetChild(2).GetChild(2).GetComponent<Image>().color = defultlevel;
            prefab.transform.GetChild(0).GetChild(2).GetChild(obj.level).GetComponent<Image>().color = upgradelevel;

            runesGameObjects.Add(prefab);
        }

        else
        {
            for (int i = 0; i < runes.Count; i++)
            {
                if (runes[i].name == obj.name)
                {
                    runes[i] = obj;
                    runesGameObjects[i].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = obj.icons[obj.level];
                    runesGameObjects[i].transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>().text = obj.name;
                    runesGameObjects[i].transform.GetChild(0).GetChild(3).GetComponent<TMP_Text>().text = obj.cooldown.ToString();
                    runesGameObjects[i].transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>().color = defultlevel;
                    runesGameObjects[i].transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<Image>().color = defultlevel;
                    runesGameObjects[i].transform.GetChild(0).GetChild(2).GetChild(2).GetComponent<Image>().color = defultlevel;
                    runesGameObjects[i].transform.GetChild(0).GetChild(2).GetChild(obj.level).GetComponent<Image>().color = upgradelevel;
                    break;
                }
            }




        }

    }

    private void Update()
    {
        for(int i = 0; i < Cooldownkeys.Count; i++)
        {
            CoolDownTime[i] -= Time.deltaTime;
            int index= Cooldownkeys[i];
            runesGameObjects[index].transform.GetChild(0).GetChild(3).GetComponent<TMP_Text>().text= CoolDownTime[i].ToString("2");
            if (CoolDownTime[i] <= 0)
            {
                runesGameObjects[index].transform.GetChild(0).GetChild(3).GetComponent<TMP_Text>().text = "R";
                CoolDownTime.RemoveAt(i);
                Cooldownkeys.RemoveAt(i);
               
            }
        }
        
    }

}
