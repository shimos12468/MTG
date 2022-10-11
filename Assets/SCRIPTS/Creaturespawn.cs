using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creaturespawn : MonoBehaviour
{
    public GameObject CreauretoSpawn;
    public Transform spawner;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        SpawnCreature();
    }

    public void SpawnCreature()
    {
        if (Input.GetKeyDown(KeyCode.U)) 
        {
            Instantiate(CreauretoSpawn,spawner);
        }
    }
}
