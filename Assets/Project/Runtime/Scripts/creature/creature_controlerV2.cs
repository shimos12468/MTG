using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creature_controlerV2 : MonoBehaviour
{
    
    
    public LineRenderer lr;
    public GameObject aimpoint;
    public Rigidbody rb;
    public float forcefactor = 50;
    public float RotationSpeed = 5;
    private Vector2 turn;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, transform.position);

        if (Input.GetKey(KeyCode.E))
        {
            rb.AddRelativeForce(0, gameObject.GetComponent<Stats>().creatureStats[7].Stat*Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            rb.AddRelativeForce(0, -gameObject.GetComponent<Stats>().creatureStats[7].Stat * 0.1f* Time.deltaTime, 0);
        }

       

        laserShoot();

       


        if (Input.GetKey(KeyCode.W))
        {
            Move(gameObject.GetComponent<Stats>().creatureStats[7].Stat, "forword");
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            Move(gameObject.GetComponent<Stats>().creatureStats[7].Stat, "backword");
            
        }

        if (Input.GetKey(KeyCode.D))
        {

            Move(gameObject.GetComponent<Stats>().creatureStats[7].Stat, "right");
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move(gameObject.GetComponent<Stats>().creatureStats[7].Stat, "left");
        }


       


    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);

    }

    private void OnCollisionExit(Collision collision)
    {
        rb.constraints = RigidbodyConstraints.FreezeRotationZ;
    }


    public void Move(float force ,string direction)
    {
        force =force*Time.deltaTime;
        if (direction=="right")
         rb.AddRelativeForce(force, 0, 0);
        if (direction=="left")
         rb.AddRelativeForce(-force, 0, 0);
        if(direction == "forword")
         rb.AddRelativeForce(0, 0, force);
        if(direction == "backword")
         rb.AddRelativeForce(0, 0, -force); 

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
            turn.x += Input.GetAxis("Mouse X");
            turn.y += Input.GetAxis("Mouse Y");
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0f);
            rb.constraints = RigidbodyConstraints.FreezeRotationZ;

        }

    }
}
