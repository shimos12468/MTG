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

    public void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }

    public GameObject GetPrefab()
    {
        return CreaturePrefab;
    }
}
