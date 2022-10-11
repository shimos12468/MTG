using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Stat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Getstat(int number ,string name)
    {
        gameObject.SetActive(true);
        transform.GetChild(1).GetComponent<TMP_Text>().text = number.ToString();
        transform.GetChild(0).GetComponent<TMP_Text>().text = name.ToString();
    }

}
