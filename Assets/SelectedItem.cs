using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedItem : MonoBehaviour
{
    private  itemMaker item;
    public GameObject myitemsHolder;
    public GameObject itemholderRemove;
    public int mygold;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GetselectedItem(itemMaker item)
    {
        this.item = item;
    }
    public void GetselectedItem(itemMaker item ,GameObject obj)
    {
        this.item = item;
        this.itemholderRemove = obj;
    }

    public void sendToPurchesdItems()
    {
        if (mygold - item.price >= 0)
        {
            if(myitemsHolder.GetComponent<displayItem>().freeplaces > 0)
                myitemsHolder.GetComponent<displayItem>().PutItem(item);
            item = null;
        }
    }


    public void removeItem()
    {
        item.defultItem();
        itemholderRemove.tag = "freeSlot";
        itemholderRemove.SetActive(false);
        myitemsHolder.GetComponent<displayItem>().freeplaces++;
        item = null;

    }
}
