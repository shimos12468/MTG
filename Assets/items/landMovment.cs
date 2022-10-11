using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landMovment : MonoBehaviour
{
    public LineRenderer lr;
    public GameObject aimpoint;
    public Rigidbody rb;
    public  Animator anim;
    
    
    public float forcefactor = 50;
    public float jumpforce = 7f;
    public bool grounded = true;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, transform.position);

        if (grounded)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                grounded = false;
                jump();
            }

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
        //rb.constraints = RigidbodyConstraints.FreezeRotation;
       

        if (collision.gameObject.tag == "ground")
        {
            forcefactor = 25;
            grounded = true;
        }
    }
    //private void OnCollisionExit(Collision collision)
    //{
    //    //rb.constraints = RigidbodyConstraints.None;

    //}


    public void Move(float force, string direction)
    {
        Debug.Log("yes he should be moving");
        if (direction == "right")
            transform.Rotate(0, 2f, 0);
        if (direction == "left")
            transform.Rotate(0, -2f, 0);
        if (direction == "forword")
            transform.Translate(Vector3.forward * Time.deltaTime * forcefactor);
       
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


           
        }

        

    }

    public void jump()
    {
        forcefactor = 5;
        rb.AddRelativeForce(0, jumpforce, 0, ForceMode.Impulse);
        
    }

   
    

}
