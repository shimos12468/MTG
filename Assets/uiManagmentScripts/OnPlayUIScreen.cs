using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayUIScreen : MonoBehaviour
{

    [SerializeField] GameObject creatureStats, characterStats;
    private bool isFoucsed;
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if(character_controler.Instance!=null)
            isFoucsed = character_controler.Instance.isFoucsed;
        if (isFoucsed)
        {
            creatureStats.SetActive(false);
            characterStats.SetActive(true);
        }
        if (!isFoucsed)
        {
            creatureStats.SetActive(true);
            characterStats.SetActive(false);
        }
    }
}
