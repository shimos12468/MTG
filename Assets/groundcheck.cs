using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundcheck : MonoBehaviour
{
    public float disttoground;
    Rigidbody rb;
    public float rotation_speed = 5;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        disttoground = gameObject.GetComponent<BoxCollider>().bounds.extents.y;
    }

    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, disttoground + 0.1f);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsGrounded())
        {

            gameObject.transform.Translate(transform.up*15*Time.deltaTime);
            rb.isKinematic = true;
            gameObject.GetComponent<BoxCollider>().isTrigger = true;

            
        }

        transform.Rotate(transform.up * 100 * Time.deltaTime);

        
    }


   
}
