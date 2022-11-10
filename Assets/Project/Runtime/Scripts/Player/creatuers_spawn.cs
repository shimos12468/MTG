using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class creatuers_spawn : MonoBehaviour
{
   
   public List <GameObject>creatures = new List<GameObject>();
    [SerializeField]
    Transform spawner;
   
    [SerializeField]
    GameObject CHARACTER;
    [SerializeField]
    public GameObject switchingManager;
    public int index;
    public TMP_Text text;


    
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
}
