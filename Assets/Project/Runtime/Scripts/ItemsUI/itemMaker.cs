using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class itemMaker : MonoBehaviour 
{
    public Transform itemList;
    public GameObject itemPrefab;
    public List<item> items = new List<item>();

    private void Start()
    {
       
    }

    public void instantiateItems()
    {

        if (itemList.childCount == 0)
        {
            for(int i = 0; i < items.Count; i++)
            {
                GameObject item = Instantiate(itemPrefab, itemList);
                item.GetComponent<itemDetails>().SetItem(items[i]);
            }
        }
    }

    public void SetPurchesedItems()
    {
        for (int i = 0; i < SWIP_creatures.Instance.purchasedItemList.childCount; i++)
        {
            Destroy(SWIP_creatures.Instance.purchasedItemList.GetChild(i));
        }

        if (SWIP_creatures.Instance.creatures.Count > 0)
        {
            for (int i = 0; i < SWIP_creatures.Instance.creatures[SWIP_creatures.Instance.index % SWIP_creatures.Instance.creatures.Count].GetComponent<Stats>().items.Count; i++)
            {
                GameObject item = Instantiate(itemPrefab, SWIP_creatures.Instance.purchasedItemList);
                item.GetComponent<itemDetails>().SetItem(SWIP_creatures.Instance.creatures[SWIP_creatures.Instance.index % SWIP_creatures.Instance.creatures.Count].GetComponent<Stats>().items[i]);
            }
        }


    }
}
