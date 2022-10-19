using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreatureStatsManager : MonoBehaviour
{

    public TMP_Text points;

    public void getcreatureforrunes(GameObject creature)
    {
        transform.GetChild(2).GetComponent<Runes_displaycreatureIcon>().displayIcon(creature.GetComponent<Stats>().creature.Icon);
        transform.GetChild(3).GetComponent<runes_displaystats>().displayStats(creature.GetComponent<Stats>().creatureStats);
        points.text = creature.GetComponent<Stats>().creature.Points.ToString();
        transform.GetChild(1).GetComponent<Runes_displayRunesTree>().get_runes(creature);

    }
    public void getcreatureforitems(GameObject creature)
    {

    }
}
