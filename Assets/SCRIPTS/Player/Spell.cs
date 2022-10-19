using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Spell : MonoBehaviour
{
    
    
    public Texture icon;
    public float speed;
    public float damage  = 0;
    public GameObject Parent;
   

    // Update is called once per frame
    void Update()
    {   
        if (speed > 0)  transform.Translate(Vector3.forward * speed * Time.deltaTime);


    }
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag != "creature" && other.gameObject.tag != "Player")
        {

            Destroy(this.gameObject);
        }

        //if (other.gameObject.tag == "enemy")
        //{
        //    other.gameObject.GetComponent<enemy>().TakeDamage(damage, Parent);
        //}
    }
    

    public void SendInfo(GameObject gameObject ,float damage)
    {
        Parent = gameObject;
        this.damage = damage;
    }
    
}
