using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureStatsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void getcreatureforrunes(GameObject creature)
    {
        transform.GetChild(2).GetComponent<Runes_displaycreatureIcon>().displayIcon(creature.GetComponent<queenflora>());
        transform.GetChild(3).GetComponent<runes_displaystats>().displayStats(creature.GetComponent<queenflora>());

        transform.GetChild(1).GetComponent<Runes_displayRunesTree>().get_runes(creature.GetComponent<RUNES_Tree>());

    }
    public void getcreatureforitems(GameObject creature)
    {

    }
}
