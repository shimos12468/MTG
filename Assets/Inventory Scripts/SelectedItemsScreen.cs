using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SelectedItemsScreen : MonoBehaviour
{

    [SerializeField] GameObject itemsList ,selectedItemPrefab ,selectedItemList;
    List<BaseItem>items= new List<BaseItem>();
    public int index = 0;
    void removeItem(int i ,int j ,BaseItem item)
    {
        items.Remove(item);
        if (items.Count <= 2)
        {
            selectedItemList.GetComponent<GridLayoutGroup>().childAlignment = TextAnchor.UpperLeft;
        }
        Destroy(itemsList.transform.GetChild(j).gameObject);
    }

  
    // Start is called before the first frame update
    void Start()
    {
        characterInventoryScreen.unAssignItem += removeItem;

        character_controler.changeselectedItem += ChangeItem;
    }

    private void ChangeItem(bool increase ,bool decrease)
    {
        if (increase)
        {

            if (index + 1 < items.Count)
            {
                index++;
                
                selectedItemList.transform.Rotate(new Vector3(0f, 0f, -90f));

                items[index].SetItemActive();
                RotateSelectedItem(index);
            }
        }
        if (decrease)
        {
            if (index - 1 >= 0)
            {
                index--;
                selectedItemList.transform.Rotate(new Vector3(0f, 0f, 90f));
                items[index].SetItemActive();
                RotateSelectedItem(index);
            }
        }

     


    }

    private void RotateSelectedItem(int index)
    {
       
        throw new NotImplementedException();

        selectedItemList.transform.Rotate(new Vector3(0f, 0f, -90f));
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(BaseItem item)
    {
        items.Add(item);
        GameObject Item = Instantiate(selectedItemPrefab, selectedItemList.transform);


       
        if (items.Count > 2)
        {
            selectedItemList.GetComponent<GridLayoutGroup>().childAlignment = TextAnchor.MiddleCenter;
        }

    }
}
