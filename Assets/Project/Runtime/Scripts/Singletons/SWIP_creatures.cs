using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SWIP_creatures : MonoBehaviour
{

    public static SWIP_creatures Instance;
    public GameObject MainMenuUI;
    public bool state = false;
    public Sprite playersprite;
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
    private void Awake()
    {
        if (Instance==null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    { 

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenuUI.SetActive(!state);
            state = !state;
        }
        if (state)
        {
            characterOptionsUI.SetActive(true);
            creatureOptionsUI.SetActive(false);
            ImageUI.sprite = playersprite;
        }
       

        if (creatures.Count > 0)
        {
            if (CreaturesIMG[index % CreaturesIMG.Count].name.Contains("creature"))
            {
                characterOptionsUI.SetActive(false);
                creatureOptionsUI.SetActive(true);
                ImageUI.sprite = CreaturesIMG[index % CreaturesIMG.Count];
            }
            else
            {
                characterOptionsUI.SetActive(true);
                creatureOptionsUI.SetActive(false);
                ImageUI.sprite = playersprite;
            }
        }
    }
    public void Addcreature(GameObject creature)
    {
        creatures.Add(creature);
        CreaturesIMG.Add(creature.GetComponent<Stats>().creature.Icon);
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
   

    

    public void SendPlayer()
    {
      
    }

    public GameObject CurrentCreature()
    {
        return creatures[index % creatures.Count];
    }

   

}
