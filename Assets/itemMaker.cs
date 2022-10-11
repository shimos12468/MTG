using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemMaker : MonoBehaviour 
{
   
   
    public int health = 0;
    public int damge =0;
    public int mana =0;
    public int magic =0;

    public int price = 1;

    public GameObject ComponantsList;
    public GameObject StatsList;
    public GameObject AddButton;
    public GameObject nameDisplayer;
    public GameObject discriptionDisplayer;
    public Sprite Icon;
    public bool compoundItem = false;
    public string Discription;
    public string Name;
    public List<itemMaker> componants = new List<itemMaker>();

    // Start is called before the first frame update
    void Start()
    {

        gameObject.GetComponent<Image>().sprite = Icon;
        gameObject.GetComponent<Image>().color = Color.white;



    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void changeItem(itemMaker item)
    {
        health = item.health;
        damge = item.damge;
        mana = item.mana;
        magic = item.magic;
        componants = item.componants;
        Icon = item.Icon;
        name = item.name;
        Discription = item.Discription;
        compoundItem = item.compoundItem;
        setChanges();
    }

    public void setChanges()
    {
        gameObject.GetComponent<Image>().sprite = Icon;
        gameObject.GetComponent<Image>().color = Color.white;
        //change the name 
        gameObject.SetActive(true);
    }
    public void sendComponants()
    {
        if (componants.Count > 0)
            ComponantsList.GetComponent<display_componant>().Getcomponants(componants);
        else
            ComponantsList.GetComponent<display_componant>().DeactivateSprites();

        sendStats();
        sendName();
        sendDiscription();
        
    }


    public void sendInfo()
    {
        sendStats();
        sendName();
        sendDiscription();
    }
    public void sendStats()
    {
        StatsList.GetComponent<displayStats>().GetStats(this);
    }
    public void sendName()
    {
        nameDisplayer.GetComponent<displayName>().GetName(Name);
    }
    public void sendDiscription()
    {
        discriptionDisplayer.GetComponent<displayDiscription>().GetDiscription(Discription);
    }

    public void sendselectedItem()
    {
        AddButton.GetComponent<SelectedItem>().GetselectedItem(this);
        
    }
    public void sendselectedItemcompound()
    {
        AddButton.GetComponent<SelectedItem>().GetselectedItem(this ,gameObject);
    }

    public void defultItem()
    {
        health = 0;
        damge = 0;
        mana = 0;
        magic = 0;
        componants = null;
        Icon = null;
        name = "name";
        Discription = "no";
        compoundItem = false;
        gameObject.GetComponent<Image>().sprite = null;
        gameObject.GetComponent<Image>().color = Color.white;
    }
}
