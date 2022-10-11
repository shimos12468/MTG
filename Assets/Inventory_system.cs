using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory_system : MonoBehaviour
{
    public float objects = 0;
    public float startPosX = -201;
    public float startPosY = 306;
    public float endPosX = -632;
    public float endPosY =306;
    bool firstTime = true;
    bool notExistingItem = true;
    float maxY = 379;
    float minY = 28;

    public Sprite crystal;
    public Sprite bone;
    public int crystalcounter =0;
    public int bonecounter = 0;

    public List<GameObject> allitems = new List<GameObject>();
    public List<GameObject> allUIitems = new List<GameObject>(0);
    public GameObject canvas;
   public GameObject UIprefab;
    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        
        other.gameObject.transform.parent = gameObject.transform;
        other.gameObject.SetActive(false);

        allitems.Add(other.gameObject);


        
        if (!firstTime)
        {
            foreach (GameObject item in allUIitems)
            {
                if (item.tag == other.tag)
                {
                    notExistingItem = false;
                    foreach (Transform child in item.transform)
                    {
                        if (child.tag == "text")
                        {

                            string text = child.gameObject.GetComponent<TMP_Text>().text;
                            int num = int.Parse(text);
                            num++;
                            child.gameObject.GetComponent<TMP_Text>().text = num.ToString();
                        }
                    }
                }
            }
        }

       


        if (notExistingItem)
        {
            GameObject UI = Instantiate(UIprefab);
            UI.transform.parent = canvas.transform;



            if (allUIitems.Count == 0)
            {
                firstTime = false;
                
                UI.gameObject.tag = other.tag;
                UI.GetComponent<RectTransform>().anchoredPosition = new Vector2(-201, startPosY);
                allUIitems.Add(UI);

                if (UI.gameObject.tag == "crystal")
                {
                    crystalcounter++;
                    UI.GetComponent<Image>().sprite = crystal;
                }
                else
                {
                    bonecounter++;
                    UI.GetComponent<Image>().sprite = bone;
                }

            }
            else
            {
                UI.gameObject.tag = other.tag;



                GameObject previos_Item = allUIitems[allUIitems.Count - 1];
                UI.GetComponent<RectTransform>().anchoredPosition = new Vector2(previos_Item.GetComponent<RectTransform>().anchoredPosition.x - 70, previos_Item.GetComponent<RectTransform>().anchoredPosition.y);



                if (UI.gameObject.tag == "crystal")
                {
                    crystalcounter++;
                    UI.GetComponent<Image>().sprite = crystal;
                }
                else
                {
                    bonecounter++;
                    UI.GetComponent<Image>().sprite = bone;
                }


                allUIitems.Add(UI);

            }
        }
        notExistingItem = true;
        objects += 1;


    }

    public void Destroy_child(GameObject child)
    {
        Debug.Log("destroy");
        Destroy(child);
    }

}
