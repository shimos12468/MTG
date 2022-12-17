using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using static utilities;
public class CharacterMenuScreen : MonoBehaviour
{
    [SerializeField] Image background ,itemPicture;
    [SerializeField] TMP_Text discription ,itemPrice ,itemTitle;
    [SerializeField] Button BuyItemButton ,AssignButton;
    [SerializeField] GameObject AssignItemButton ,BoughtGameObject ,BuyGameObject ,AssignedButton;
    [SerializeField] GameObject allItemsList;
    [SerializeField] GameObject itemsListPrefab;
    [SerializeField] GameObject itemsContainThisItemList;
    [SerializeField] GameObject itemsContainThisItemprefab;

    public Color EnabledColor;
    public Color DisabledColor;
    public Color AssginedButton;
    private int currentItem = -1;
    GameObject character;
    List<BaseItem> allitems;

    //private void Awake()
    //{
    //    menu.Object += GetObject;

    //    BuyItemButton.onClick.AddListener(()=>BuyItem());
    //}

    //private void BuyItem()
    //{

    //    Debug.Log("hello");
    //    if (currentItem != -1)
    //    {
    //        CharacterInventory ci= character.GetComponent<CharacterInventory>();    
    //        if (ci != null)
    //        {
    //            CharacterInventory.allItems.Add(allitems[currentItem]);
    //            allitems[currentItem].owned= true;
               
    //            AssignItemButton.SetActive(allitems[currentItem].owned);
    //            BuyGameObject.SetActive(!allitems[currentItem].owned);
    //            BoughtGameObject.SetActive(allitems[currentItem].owned);   
    //            AssignButton.onClick.AddListener(()=>AssigneItem());
                

    //        }
    //    }
    //}

    private void AssigneItem()
    {
        if (currentItem != -1)
        {
            AssignedButton.SetActive(true);
            AssignItemButton.SetActive(false);
            allitems[currentItem].assigned = true;
            allitems[currentItem].AssignItem(character ,new List<GameObject>());
        }
    }

    public void OnItemClicked(int i)
    {
        if (i < allitems.Count)
        {
            currentItem= i;
            itemPicture.sprite = allitems[i].Icon;
            itemPrice.text = allitems[i].price.ToString();
            discription.text = allitems[i].discription.ToString();
            itemTitle.text = allitems[i].name.ToString();
            AssignItemButton.SetActive(!allitems[i].assigned);
            AssignedButton.SetActive(allitems[i].assigned);
            BoughtGameObject.SetActive(allitems[i].owned);
            BuyGameObject.SetActive(!allitems[i].owned);
            
           
        }
        Debug.Log(allitems[i].name);

    }
    //private void Start()
    //{
    //     populateItems();
    //}
    //private void populateItems()
    //{
    //    allitems= new List<BaseItem>(ItemsInventory.allItems);
       

    //    for (int i = 0;  i < allitems.Count;i++)
    //    {
    //        GameObject item = Instantiate(itemsListPrefab, allItemsList.transform);

    //        item.GetComponent<ItemIdentity>().index = i;
    //        item.GetComponent<Image>().sprite = allitems[i].Icon;
    //        item.GetComponent<Image>().color = allitems[i].enabled ? EnabledColor : DisabledColor;

    //    }


    //}

    private void GetObject(GameObject obj)
    {

        if (obj.tag == "Player")
        {
            character = obj;
            background.enabled = true;
            for (int i = 0; i < transform.childCount; i++)
                transform.GetChild(i).gameObject.SetActive(true);

            
        }
    }

}
