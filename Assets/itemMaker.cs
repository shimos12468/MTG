using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct itemStats
{
    public statType name;
    public float stat;
}

[System.Serializable]
public struct item
{
    public string name;
    public List<itemStats> stats;
    public int price;
    public Sprite Icon;
    public string Discription;
    public bool ownership;
}



public class itemMaker : MonoBehaviour 
{
    public Transform itemList;
    public GameObject itemPrefab;
    public List<item> items = new List<item>();
    
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


}
