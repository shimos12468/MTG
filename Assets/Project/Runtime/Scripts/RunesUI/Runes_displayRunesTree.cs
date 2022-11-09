using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runes_displayRunesTree : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void get_runes(GameObject runes)
    {

         int count= runes.GetComponent<Stats>().runes.Count;
         Debug.Log(count);
        for (int i = 0; i < count; i++)
        {
            if (gameObject.transform.GetChild(i).GetComponent<Rune>())
            {
                transform.GetChild(i).GetComponent<Rune>().creature =runes;
                transform.GetChild(i).GetComponent<Rune>().check(runes.GetComponent<Stats>().runes[i]);
            }
        }
       

    }
}
