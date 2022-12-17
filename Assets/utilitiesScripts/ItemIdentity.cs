using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIdentity : MonoBehaviour
{

    public int index = -1;

    characterInventoryScreen characterInventoryscreen;

    private void Awake()
    {
        characterInventoryscreen = GameObject.FindGameObjectWithTag("characterInventoryScreen").GetComponent<characterInventoryScreen>();
       

    }

    public void Onclicked()
    {
        characterInventoryscreen.OnItemClicked(index);
    }
   
}
