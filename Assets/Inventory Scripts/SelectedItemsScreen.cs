using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedItemsScreen : MonoBehaviour
{

    [SerializeField] GameObject itemsList;
    void removeItem(int i ,int j)
    {
        Destroy(itemsList.transform.GetChild(j).gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        characterInventoryScreen.unAssignItem += removeItem;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
