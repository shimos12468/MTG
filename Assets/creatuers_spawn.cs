using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creatuers_spawn : MonoBehaviour
{
   
   public List <GameObject>creatures = new List<GameObject>();
    [SerializeField]
    Transform spawner;
    [SerializeField]
    GameObject playerCam;
    [SerializeField]
    GameObject CHARACTER;
    [SerializeField]
    GameObject switchingManager;
   
    public void spawncreature(int i)
    {
        GameObject creature = Instantiate(creatures[i], spawner);
        creature.transform.parent = null;
        creature.gameObject.transform.position = spawner.transform.position;
        //playerCam.gameObject.SetActive(false);

        gameObject.GetComponent<character_controler>().isFoucsed = false;
        switchingManager.GetComponent<switchingManager>().Addcreature(creature);

    }
}
