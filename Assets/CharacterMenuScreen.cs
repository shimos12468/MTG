using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenuScreen : MonoBehaviour
{
    [SerializeField] Image background ,itemPicture;
    [SerializeField] Text discription ,itemPrice ,itemTitle;
    [SerializeField] Button BuyItemButtonButton;
    [SerializeField] GameObject allItemsList;
    [SerializeField] GameObject itemsListPrefab;
    [SerializeField] GameObject itemsContainThisItemList;
    [SerializeField] GameObject itemsContainThisItemprefab;
    private void Awake()
    {
        menu.Object += GetObject;
    }

    private void GetObject(GameObject obj)
    {

        if (obj.tag == "Player")
        {

            background.enabled = true;
            for (int i = 0; i < transform.childCount; i++)
                transform.GetChild(i).gameObject.SetActive(true);

        }
    }


}
