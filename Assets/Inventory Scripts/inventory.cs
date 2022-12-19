using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{

    GameObject characterInventory;
    public Transform center;
    public float reduis = 15f;
    public bool activate = true;
    List<BaseItem>items= new List<BaseItem>();  
    List<BaseItem>SelectedItems= new List<BaseItem>(4) {new BaseItem()  , new BaseItem(), new BaseItem(), new BaseItem() };
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        characterInventoryScreen.Assignitem += AssignItem;
        characterInventoryScreen.unAssignItem += UnAssignItem;
        characterInventory = GameObject.FindGameObjectWithTag("characterInventoryScreen");
        characterInventory.SetActive(false);   
    }

    private void UnAssignItem(int i , int j)
    {

        items.RemoveAt(i);
        SelectedItems.RemoveAt(j);
    }

    private void AssignItem(int i)
    {
        
        items[i].assigned = true;
        SelectedItems[count % 4] = items[i];
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<character_controler>().isFoucsed)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                characterInventory.SetActive(activate);
                activate = !activate;
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                Collider[] hitColliders = Physics.OverlapSphere(center.position, reduis);
                Debug.Log(hitColliders.Length);
                if (hitColliders.Length > 0)
                {
                    for (int i = 0; i < hitColliders.Length; i++)
                    {
                       
                        if (hitColliders[i].tag == "item")
                        {
                            hitColliders[i].transform.parent = center;
                            hitColliders[i].transform.Translate( new Vector3(center.position.x , 1 ,center.position.z)*Time.deltaTime*1,Space.World );
                            


                           
                            if (hitColliders[i].GetComponent<BaseItem>())
                            {

                                items.Add(hitColliders[i].GetComponent<BaseItem>());
                                Debug.Log(hitColliders[i]+"  "+ i);
                                characterInventory.GetComponent<characterInventoryScreen>().AddItem(hitColliders[i].GetComponent<BaseItem>());
                                

                            }
                            hitColliders[i].gameObject.SetActive(false);
                        }
                    }

                }

            }
        }
        

    }


    

}
