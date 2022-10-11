using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creatureMovment : MonoBehaviour
{

    [SerializeField]
    float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            gameObject.transform.Translate(Time.deltaTime * transform.forward * speed);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            gameObject.transform.Translate(-Time.deltaTime * transform.forward * speed);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(0, 2f, 0);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(0, -2f, 0);
        }

    }
}
