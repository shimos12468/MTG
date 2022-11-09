using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class displayName : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetName(string name)
    {
        transform.GetComponent<TMP_Text>().text = name.ToString();
        transform.gameObject.SetActive(true);
    }
}
