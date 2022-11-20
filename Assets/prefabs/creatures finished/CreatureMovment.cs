using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMovment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Movment(gameObject.GetComponent<Stats>().creatureStats[7].Stat * Time.deltaTime ,Vector3.up);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            Movment(gameObject.GetComponent<Stats>().creatureStats[7].Stat * Time.deltaTime, Vector3.down);
        }
    }
    public void Movment(float speed ,Vector3 direction)
    {
        transform.Translate(direction * speed); 
    }
}
