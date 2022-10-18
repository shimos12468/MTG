using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Spell : MonoBehaviour
{
    //public SpellSO spell1;
    private SphereCollider mycollider;
    private Rigidbody myrigidbody;
    public Texture icon;
    public string name;
    public string description;
    public int id;
    public float speed;
    public float tolerance;
    public float damage  = 0;
    public GameObject Parent;
   

    // Update is called once per frame
    void Update()
    {   
        if (speed > 0)  transform.Translate(Vector3.forward * speed * Time.deltaTime);


    }
    //private void OnTriggerEnter(Collider other)
    //{

    //    Debug.Log(other.gameObject.tag);
    //    if (other.gameObject.tag != "creature" && other.gameObject.tag != "Player")
    //    {
           
    //        Destroy(this.gameObject);
    //    }

    //    if (other.gameObject.tag == "enemy")
    //    {
    //        other.gameObject.GetComponent<enemy>().TakeDamage(damage ,Parent);
    //    }
    //}
    //IEnumerator toleranceRoutine()
    //{
    //    yield return new WaitForSeconds(tolerance);
    //    GetComponent<Collider>().isTrigger = true;
        
    //}

    //public void setparent(GameObject gameObject)
    //{
    //    Parent = gameObject;
    //}
    //private void O(Collision collision)
    //{
        
       
    //}
}
