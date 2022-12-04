using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    public GameObject content;
    [SerializeField] GameObject objectPrefab;

    private List<GameObject> objectsList = new List<GameObject>();

    public static  Action<GameObject> Object;

   
   
    private void OnEnable()
    {
        UiBehavior.menuAction = enableui;

    }
    



    public void enableui(List<GameObject> objs ,GameObject player)
    {
        content.transform.GetChild(0).gameObject.GetComponent<ObjectIdentityComponant>().SetObject(player);

        objectsList = objs;

        RefreshList();

        for (int i = 0; i < objs.Count; i++)
        {

            GameObject ui = Instantiate(objectPrefab, content.transform);

            bool flag = objs[i].GetComponent<Stats>() ? true : false;
            if (flag)
            {
                ui.gameObject.name  = objs[i].name;
                ui.GetComponent<ObjectIdentityComponant>().SetObject(objs[i]); 
                ui.GetComponent<Image>().color = Color.white;
                ui.GetComponent<Image>().sprite = objs[i].GetComponent<Stats>().creature.Icon;
            }

        }

       
       
     
    }

    private void RefreshList()
    {



        for (int i = 1; i < content.transform.childCount; i++)
        {
            Destroy(content.transform.GetChild(i).gameObject);
        }


    }

    public void onClickObject(int index)
    {
        Debug.Log("hala" + index);
        Object?.Invoke(objectsList[index]);
    }
}

