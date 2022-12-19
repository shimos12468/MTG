using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class characterInventoryScreen : MonoBehaviour
{
    [SerializeField] TMP_Text Title, discription;
    [SerializeField] SelectedItemsScreen SelectedItemsScreen;
    [SerializeField] GameObject itemPrefab,itemlist ,assign ,unAssign;
    [SerializeField] Button itembutton;
    public static event Action<int>Assignitem;
    public static event Action<int ,int ,BaseItem> unAssignItem;
    private int counter = 0;
    private int selectedLimit = 4;
    private int selectedCounter = 0;
    private int selected = -1;
    List<BaseItem> items = new List<BaseItem>();
    List<BaseItem> selectedItems = new List<BaseItem>();
    public void AddItem<T>(T item)where T : BaseItem
    {
        items.Add(item);

        GameObject Item = Instantiate(itemPrefab ,itemlist.transform);
        Item.GetComponent<Image>().sprite = item.Icon;
        Item.AddComponent<Button>();
        Item.SetActive(true);
        Item.GetComponent<ItemIdentity>().index = counter;
        counter++;
        Title.text = item.name;
        discription.text = item.discription;
    }

    public void OnItemClicked(int index)
    {
        selected = index;
        discription.text = items[index].discription;
        Title.text = items[index].name;
        if (items[index].assigned == true)
        {
            unAssign.SetActive(true);
            assign.SetActive(false);
        }
        else
        {
            unAssign.SetActive(false);
            assign.SetActive(true);
        }
    }

    public void AssignItem()
    {

        if (selectedCounter < selectedLimit)
        {
            Debug.Log(selected + " hello" + selectedCounter + "  ");
            Assignitem?.Invoke(selected);
            unAssign.SetActive(true);
            assign.SetActive(false);
            items[selected].assigned = true;
            selectedCounter++;

            SelectedItemsScreen.AddItem(items[selected]);

            selectedItems.Add(items[selected]);


        }

    }


    public void UnAssignItem()
    {
        int ind = -1;
        for(int i = 0;i< selectedItems.Count;i++)
        {
            if (items[selected].GetInstanceID() == selectedItems[i].GetInstanceID())
            {
                ind = i; break;
            }
        }
       
        unAssignItem?.Invoke(selected ,ind, selectedItems[ind]);
        selectedItems.RemoveAt(ind);
        unAssign.SetActive(false);
        assign.SetActive(true);
        items[selected].assigned = false;
        selectedCounter--;
    }
    
}
