using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayItem : MonoBehaviour
{

    
    public int freeplaces = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PutItem(itemMaker item)
    {
        foreach(Transform child in transform)
        {
            if (child.tag == "freeSlot")
            {
                child.GetComponent<itemMaker>().changeItem(item);
                child.tag = "busySlot";
                child.gameObject.SetActive(true);


                //add to player;
                break;
            }
            
        }


        freeplaces--;
    }
}
