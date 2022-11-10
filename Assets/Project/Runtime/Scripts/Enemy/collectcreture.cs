using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectcreture : MonoBehaviour
{


    [SerializeField]
    GameObject CreaturePrefab;

    public void UiEnable()
    {
        //by die animation event
    }

    public GameObject GetCreaturePrefab()
    {
        return CreaturePrefab;
    }

    public void SendPrefab()
    {
        Debug.Log("clicked");
        switchingManager.Instance.player.GetComponent<creatuers_spawn>().AddPrefab(CreaturePrefab);

    }
}
