using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class displayDiscription : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetDiscription(string discription)
    {
        transform.GetComponent<TMP_Text>().text = discription.ToString();
        transform.gameObject.SetActive(true);
    }
}
