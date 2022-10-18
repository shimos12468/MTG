using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class itemDetails : MonoBehaviour
{
    
    public TMP_Text price;
    public Button itemButton;
    public TMP_Text itemName;
    public Image itemIcon;
    public item thisitem;
    public GameObject itemPrefab;
    public TMP_Text itemDiscription;
    public GameObject statAsset;
    public Transform contentList;
    public GameObject purcheseditemList;
    GameObject currentCreature = null;
    SWIP_creatures CreaturesList;

    
    void Start()
    {
        CreaturesList = GameObject.FindGameObjectWithTag("GameMenu").GetComponent<SWIP_creatures>();
        purcheseditemList = GameObject.FindGameObjectWithTag("PurchasedItemsList");
    }

    public void purchaseItem()
    {
        CurrentCreature();
        if (currentCreature != null)
        {
            currentCreature.GetComponent<Stats>().items.Add(thisitem);
            GameObject a = Instantiate(itemPrefab, purcheseditemList.transform);
            a.GetComponent<itemDetails>().SetItem(thisitem);
        }
    }

    public void CurrentCreature()
    {
        currentCreature = CreaturesList.CurrentCreature();
    }

    public void SetItem(item item)
    {
        thisitem = item;
        price.text = item.price.ToString();
        itemDiscription.text = item.Discription;
        itemName.text = item.name;
        itemIcon.sprite = item.Icon;
        for (int i = 0; i < item.stats.Count; i++)
        {
            GameObject stat = Instantiate(statAsset, contentList);
            stat.transform.GetChild(0).GetComponent<TMP_Text>().text = item.stats[i].stat + "     " + item.stats[i].name;
        }
    }


    public void SetItem(item item ,itemDetails itemAsset)
    {
        itemAsset.thisitem = item;
        itemAsset.price.text = item.price.ToString();
        itemAsset.itemDiscription.text = item.Discription;
        itemAsset.itemName.text = item.name;
        itemAsset.itemIcon.sprite = item.Icon;
        
        for (int i = 0; i < item.stats.Count; i++)
        {
            GameObject stat = Instantiate(itemAsset.statAsset, itemAsset.contentList);
            stat.transform.GetChild(0).GetComponent<TMP_Text>().text = item.stats[i].stat + "     " + item.stats[i].name;
        }
    }


}
