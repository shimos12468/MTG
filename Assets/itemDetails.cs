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
            if (currentCreature.GetComponent<Stats>().creature.coins >= thisitem.price)
            {
                currentCreature.GetComponent<Stats>().creature.coins -= thisitem.price;
                thisitem.ownership = true;
                currentCreature.GetComponent<Stats>().items.Add(thisitem);
                
                GameObject a = Instantiate(itemPrefab, purcheseditemList.transform);
                a.GetComponent<itemDetails>().SetItem(thisitem);
                thisitem.ownership = false;
                currentCreature.GetComponent<Stats>().UpdateStats(thisitem ,'A');
            }
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


    public void RemoveItem()
    {
        CurrentCreature();
       for(int i = 0; i < currentCreature.GetComponent<Stats>().items.Count; i++)
        {
            if(thisitem.name== currentCreature.GetComponent<Stats>().items[i].name)
            {
                currentCreature.GetComponent<Stats>().items.RemoveAt(i);
              
                
                currentCreature.GetComponent<Stats>().UpdateStats(thisitem ,'R');
                Destroy(this.gameObject);
                break;
            }
        }
    }

    public void SetItem(item item ,itemDetails itemAsset)
    {
        itemAsset.thisitem = item;
        itemAsset.price.text = item.price.ToString();
        itemAsset.itemDiscription.text = item.Discription;
        itemAsset.itemName.text = item.name;
        itemAsset.itemIcon.sprite = item.Icon;
        
        //for (int i = 0; i < item.stats.Count; i++)
        //{
        //    GameObject stat = Instantiate(itemAsset.statAsset, itemAsset.contentList);
        //    stat.transform.GetChild(0).GetComponent<TMP_Text>().text = item.stats[i].stat + "     " + item.stats[i].name;
        //}
    }


}
