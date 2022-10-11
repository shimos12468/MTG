using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayStats : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetStats(itemMaker stats)
    {
        DeactivateSprites();
        int i = 0;
        Debug.Log(stats.health);

        if (stats.health > 0)
        {
            transform.GetChild(i).GetComponent<Stat>().Getstat(stats.health ,"health");
            i++;
        }
        if (stats.magic > 0)
        {
            i++;
            transform.GetChild(i).GetComponent<Stat>().Getstat(stats.magic, "magic");
        }
        if (stats.mana > 0)
        {
            i++;
            transform.GetChild(i).GetComponent<Stat>().Getstat(stats.mana, "mana");

        }
        if (stats.damge > 0)
        {
            i++;
            transform.GetChild(i).GetComponent<Stat>().Getstat(stats.damge, "damge");

        }

       
        
    }

    public void DeactivateSprites()
    {
        int count = transform.childCount;
        for (int i = 0; i < count; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
