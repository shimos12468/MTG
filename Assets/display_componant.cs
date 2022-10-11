using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class display_componant : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Getcomponants(List<itemMaker>componants)
    {

        DeactivateSprites();
        int count = componants.Count;
        for(int i = 0; i < count; i++)
        {
          transform.GetChild(i).GetComponent<itemMaker>().changeItem(componants[i]);
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
