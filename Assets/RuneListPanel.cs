using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static utilities;

public class RuneListPanel : MonoBehaviour
{
    [SerializeField] GameObject runeprefab;
    [SerializeField] Color defultlevel ,upgradelevel;
    private List<GameObject> runesGameObjects = new List<GameObject>();
    private List<Rune> runes = new List<Rune>();

    private void Awake()
    {
        Stats.CreatureRunesPanel += updateList;
    }

    private void updateList(Rune obj ,bool NewRune)
    {
        if (NewRune)
        {
            runes.Add(obj);

           GameObject prefab = Instantiate(runeprefab ,transform);
           prefab.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = obj.icons[obj.level];
           prefab.transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>().text = obj.name;
           prefab.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>().color = defultlevel;
           prefab.transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<Image>().color = defultlevel;
           prefab.transform.GetChild(0).GetChild(2).GetChild(2).GetComponent<Image>().color = defultlevel;
           prefab.transform.GetChild(0).GetChild(2).GetChild(obj.level).GetComponent<Image>().color = upgradelevel;

            runesGameObjects.Add(prefab);   
        }

        else
        {
            for(int i = 0; i < runes.Count; i++)
            {
                if (runes[i].name == obj.name)
                {
                    runes[i] = obj;
                    runesGameObjects[i].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = obj.icons[obj.level];
                    runesGameObjects[i].transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>().text = obj.name;
                    runesGameObjects[i].transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>().color = defultlevel;
                    runesGameObjects[i].transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<Image>().color = defultlevel;
                    runesGameObjects[i].transform.GetChild(0).GetChild(2).GetChild(2).GetComponent<Image>().color = defultlevel;
                    runesGameObjects[i].transform.GetChild(0).GetChild(2).GetChild(obj.level).GetComponent<Image>().color = upgradelevel;

                }
            }




        }

    }


   
}
