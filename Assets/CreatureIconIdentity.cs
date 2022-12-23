using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreatureIconIdentity : MonoBehaviour
{


    public GameObject parent;
    public int index = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnButtonClick()
    {
        parent.GetComponent<CharacterTeamScreen>().Onclick(index);
    }
}
