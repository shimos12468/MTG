using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public float health =7;
    public float Damage =1;
    public GameObject player;
    public GameObject creature = null;
    public GameObject [] items = new GameObject[2];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        creature = GameObject.FindGameObjectWithTag("creature");
        if (creature != null)
        {

        transform.LookAt(creature.transform);
        transform.Translate(3 * transform.forward * Time.deltaTime);
        }
        creature = null;
        }


    public void TakeDamage(float damage ,GameObject parent)
    {
        health -= damage;
        if (health <= 0)
        {
            
                int num= Random.Range(0,items.Length);
                
                GameObject itmm= Instantiate(items[num], gameObject.transform);
                itmm.transform.parent = null;
               
                itmm.transform.position =transform.position;
                

                parent.GetComponent<queenflora>().Expactual += 5;
                parent.GetComponent<queenflora>().setUI();

            Destroy(this.gameObject);
        }
    }
}
