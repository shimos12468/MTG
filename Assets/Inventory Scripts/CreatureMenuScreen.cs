using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using static utilities;
public class CreatureMenuScreen : MonoBehaviour
{

    [SerializeField] Image background;
    [SerializeField] TMP_Text creatureName;


    public GameObject runePrefab;
    public RectTransform map;
    List<GameObject> runesgameObject = new List<GameObject>();
    List<Rune>runes = new List<Rune>();
    public HealthRune health;
   

    private void Awake()
    {
        runes.Add(health);
        
        DisplayRunes();
    }


    public void RuneClicked(int i)
    {

    }

    public  void GetObject(GameObject obj)
    {
        creatureName.text = obj.GetComponent<Stats>().creature.name;
        if (obj.tag == "Creature")
        {
            background.enabled = true;
            for (int i = 0; i < transform.childCount; i++)
                transform.GetChild(i).gameObject.SetActive(true);
        }


      
    }
    void DisplayRunes()
    {

        int number = runes.Count;
        float width = map.rect.width;
        float height = map.rect.height;

        GameObject prefab = Instantiate(runePrefab, map);
        Vector3 position=  Vector3.zero;
        prefab.transform.position =position;

        runesgameObject.Add(prefab);
        Vector3[] positions = {new Vector3(0,1,0) ,new Vector3(2,0,0) ,new Vector3(2,1,0), new Vector3(0, -1, 0), new Vector3(-2, 0, 0), new Vector3(-2, -1, 0) , new Vector3(2, -1, 0), new Vector3(-2, 1, 0) };

        int constant = 50;
        for (int i = 1; i <=20; i++)
        {
            int distance = i * constant+155;

            if(-width/2< (positions[i % positions.Length] * distance).x && (positions[i % positions.Length] * distance).x < width / 2)
            {
                if (-height / 2 < (positions[i % positions.Length] * distance).y && (positions[i % positions.Length] * distance).y < height / 2)
                {
                    GameObject objec = Instantiate(runePrefab, map);
                    
                    objec.transform.position = positions[i % positions.Length] * distance;
                    objec.GetComponent<UIutilities>().index = i;
                    runesgameObject.Add(objec);
                }

            }
             

        }


        for(int i = 0; i < runes.Count; i++)
        {
            runesgameObject[i].GetComponent<UIutilities>().index= i;
            runesgameObject[i].GetComponent<UIutilities>().SetupUI(runes[i].name , 
                runes[i].level.ToString()
                , runes[i].priceForUnlock.ToString()
                , runes[i].icons[runes[i].level]
                , runes[i].stats);


        }



    }


}
