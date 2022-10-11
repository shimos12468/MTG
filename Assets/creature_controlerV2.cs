using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creature_controlerV2 : MonoBehaviour
{
    
    
    public LineRenderer lr;
    public GameObject aimpoint;
    public Rigidbody rb;
    public float forcefactor = 50;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, transform.position);

        if (Input.GetKey(KeyCode.E))
        {
            rb.AddRelativeForce(0, forcefactor, 0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            rb.AddRelativeForce(0, -forcefactor * 0.3f, 0);
        }


        laserShoot();


       
       
        if (Input.GetKey(KeyCode.W))
        {
            Move(forcefactor, "forword");
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            Move(forcefactor, "backword");
            
        }

        if (Input.GetKey(KeyCode.D))
        {

            Move(forcefactor, "right");
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move(forcefactor, "left");
        }


       


    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);

    }
    //private void OnCollisionExit(Collision collision)
    //{
    //    //rb.constraints = RigidbodyConstraints.None;

    //}


    public void Move(float force ,string direction)
    {
        if(direction=="right")
         rb.AddRelativeForce(forcefactor, 0, 0);
        if (direction=="left")
         rb.AddRelativeForce(-forcefactor, 0, 0);
        if(direction == "forword")
         rb.AddRelativeForce(0, 0, forcefactor);
        if(direction == "backword")
         rb.AddRelativeForce(0, 0, -forcefactor); 

    }
    public void laserShoot()
    {
        if (Input.GetMouseButton(1))
        {

            Camera c = Camera.main;
            Vector3 p = c.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100));

            lr.SetPosition(1, p);

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.collider)
                {
                    p = new Vector3(p.x, p.y, hit.point.z);
                    lr.SetPosition(1, p);
                }
            }

            else
            {
                lr.SetPosition(1, p);
            }
            aimpoint.transform.LookAt(p);


            rb.constraints = RigidbodyConstraints.FreezeAll;
            gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
        }

        if (!Input.GetMouseButton(1))
        {

            rb.constraints = RigidbodyConstraints.FreezeRotation;

        }

    }
}
