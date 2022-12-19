using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayUIScreen : MonoBehaviour
{

    [SerializeField] GameObject creatureStats, characterStats;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (character_controler.Instance.isFoucsed)
        {
            creatureStats.SetActive(false);
            characterStats.SetActive(true);
        }
        if (!character_controler.Instance.isFoucsed)
        {
            creatureStats.SetActive(true);
            characterStats.SetActive(false);
        }
    }
}
