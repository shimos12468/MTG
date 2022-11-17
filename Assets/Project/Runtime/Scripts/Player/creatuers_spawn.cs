using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class creatuers_spawn : MonoBehaviour
{
   
    public static creatuers_spawn instance;
    public List <GameObject>creatures = new List<GameObject>();

    [SerializeField]
    Transform spawner;
   
    [SerializeField]
    GameObject CHARACTER;
    [SerializeField]
    public GameObject switchingManager;
    public int index;
    public TMP_Text text;


    private void Start()
    {
        if (instance == null) instance = this;
        else Destroy(this);


        GameObject right = GameObject.FindGameObjectWithTag("swipeRight");
        GameObject left = GameObject.FindGameObjectWithTag("swipeLeft");
        GameObject Text = GameObject.FindGameObjectWithTag("swipeLeft");
        text = Text.GetComponent<TMP_Text>();
        right.GetComponent<Button>().onClick.AddListener(() => swipe_right());
        left.GetComponent<Button>().onClick.AddListener(() => swipe_left());

    }

    public void spawncreature()
    {
        GameObject creature = Instantiate(creatures[index], spawner);
        creature.transform.parent = null;
        creature.gameObject.transform.position = spawner.transform.position;
       

        gameObject.GetComponent<character_controler>().isFoucsed = false;
        switchingManager.GetComponent<switchingManager>().Addcreature(creature);

    }

    public void swipe_right()
    {
        int m = index + 1;
        if (m < creatures.Count)
        {
            index++;
            Debug.Log(creatures[index].name);
            text.text = creatures[index].GetComponent<Stats>().creature.name;
        }
    }

    public void swipe_left()
    {
        int m = index - 1;
        if (m >= 0)
        {
            index--;
            text.text = creatures[index].GetComponent<Stats>().creature.name;
        }
    }


    public void AddPrefab(GameObject CreaturePrefab)
    {
        Debug.Log("Added");
        creatures.Add(CreaturePrefab);
    }
}
