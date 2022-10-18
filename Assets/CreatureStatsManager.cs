using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureStatsManager : MonoBehaviour
{
    


    public void getcreatureforrunes(GameObject creature)
    {
        transform.GetChild(2).GetComponent<Runes_displaycreatureIcon>().displayIcon(creature.GetComponent<Stats>().creature.Icon);
        transform.GetChild(3).GetComponent<runes_displaystats>().displayStats(creature.GetComponent<Stats>().creatureStats);

        transform.GetChild(1).GetComponent<Runes_displayRunesTree>().get_runes(creature);

    }
    public void getcreatureforitems(GameObject creature)
    {

    }
}
