using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SWIP_creatures : MonoBehaviour
{
    
    public GameObject MainMenuUI;
    public bool state = false;

    public  GameObject RunesUI;
    public GameObject ItemsUI;
    public GameObject itemPrefab;
    public List<GameObject> creatures = new List<GameObject>();
    public Image ImageUI;
    public List<Sprite> CreaturesIMG = new List<Sprite>();
    public GameObject characterOptionsUI;
    public GameObject creatureOptionsUI;
    public int index = 0;
    public Transform purchasedItemList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            MainMenuUI.SetActive(!state);
            state = !state;
        }


        if (creatures.Count > 0)
        {

            if (CreaturesIMG[index % CreaturesIMG.Count].name.Contains("creature"))
            {
                characterOptionsUI.SetActive(false);
                creatureOptionsUI.SetActive(true);
            }
            else
            {
                characterOptionsUI.SetActive(true);
                creatureOptionsUI.SetActive(false);
            }
        }
    }


    
    public void swipe_right()
    {

        if (creatures.Count > 0)
        { 
            index++;
            ImageUI.sprite = CreaturesIMG[index % CreaturesIMG.Count];
        }
    }

    public void swipe_left()
    {

        if (creatures.Count > 0)
        {
            index--;
            if (index < 0)
                index = CreaturesIMG.Count - 1;
            ImageUI.sprite = CreaturesIMG[index % CreaturesIMG.Count];
        }
    }
   

    public void sendcreature(bool r)
    {
        if (r)
        {

            RunesUI.GetComponent<CreatureStatsManager>().getcreatureforrunes(creatures[index%creatures.Count]);
        }
       
    }


    public GameObject CurrentCreature()
    {
        return creatures[index % creatures.Count];
    }

    public void SetPurchesedItems()
    {
        for (int i = 0; i < purchasedItemList.childCount; i++)
        {
            Destroy(purchasedItemList.GetChild(i));
        }

        for (int i = 0; i < creatures[index % creatures.Count].GetComponent<Stats>().items.Count; i++)
        {
            GameObject item = Instantiate(itemPrefab, purchasedItemList);
            item.GetComponent<itemDetails>().SetItem(creatures[index % creatures.Count].GetComponent<Stats>().items[i]);
        }

    }

}
