using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemenu : MonoBehaviour
{
    public List<GameObject> deactivate = new List<GameObject>();
    public GameObject menu;

    public bool state= false;
    private void Awake()
    {
       
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
        //if (Input.GetKey(KeyCode.Escape))
        //{
        //    SceneManager.LoadScene("menu");
        //}
    }
    
}
