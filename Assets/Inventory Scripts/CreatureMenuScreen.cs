using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatureMenuScreen : MonoBehaviour
{

    [SerializeField] Image background;
    private void Awake()
    {
        menu.Object += GetObject;
    }

    private void GetObject(GameObject obj)
    {

        if (obj.tag == "Creature")
        {
            background.enabled = true;
            for (int i = 0; i < transform.childCount; i++)
                transform.GetChild(i).gameObject.SetActive(true);
        }

    }


}
