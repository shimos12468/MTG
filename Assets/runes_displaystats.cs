using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class runes_displaystats : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void displayStats(queenflora q)
    {

            GameObject health= transform.GetChild(0).gameObject;
            foreach(Transform stat in health.transform)
            {
                if (stat.GetComponent<TMP_Text>())
                {
                stat.GetComponent<TMP_Text>().text = q.Health.ToString();              
                }

            }
        

    }
}
