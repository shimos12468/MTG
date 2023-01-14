
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
public class movment : MonoBehaviour
{


    public GameObject model;

    [SerializeField, Range(1f, 50f)]
    float speed = 10;
    [SerializeField, Range(1f, 100f)]
    float acc = 10;

    [SerializeField, Range(1f, 100)]
    float maxSpeed = .1f;

    [SerializeField, Range(1f, 10)]
    float Multiplayer = 2f;

    [SerializeField, Range(10f, 50f)]
    float takingOffSpeed = 2f;

    [SerializeField, Range(10f, 50f)]
    float HeightLimit = 20f;

    [SerializeField, Range(10f, 50f)]
    float FlayingAcceleration = 20f;
    Vector2 turn;

    [SerializeField, Range(10f, 1000f)]
    float rotationSpeed = 200;
    public enum MovmentStates
    {
        OnGround ,
        Flaying ,
        TakeOff ,
        Landing
    }
    Vector3 v;
    void OnValidate()
    {
       
    }
    void Start()
    {
        v = transform.position;
    }

    
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X");
        transform.rotation = Quaternion.Euler(0, turn.x, 0f);

        if (!Input.anyKey)
        {
            speed = Mathf.MoveTowards(speed, 0, acc * Multiplayer * Time.deltaTime);
        }
        else
        {
            speed = Mathf.MoveTowards(speed, maxSpeed, acc * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.W))
        {

            Vector3 b = transform.localPosition;
            b.y = 0;
            b.x = 0;
            b.z = 1;
            transform.Translate((b*  speed * Time.deltaTime));
        }

        if (speed >= takingOffSpeed&&transform.position.y<HeightLimit)
        {
           
            v.y= Mathf.MoveTowards(v.y, transform.position.y + HeightLimit, FlayingAcceleration * Time.deltaTime);
            transform.position =new Vector3(transform.position.x ,v.y ,transform.position.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            
            Vector3 b = transform.localPosition;
            b.y = 0;
            b.x = 1;
            b.z = 0;
            transform.Translate(b * speed * Time.deltaTime);
            Quaternion wantedRotation = Quaternion.Euler(0, 0, -30);
            model.transform.localRotation = Quaternion.RotateTowards(model.transform.localRotation, wantedRotation, Time.deltaTime * rotationSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 b = transform.localPosition;
            b.y = 0;
            b.x = 1;
            b.z = 0;
            transform.Translate(-b * speed * Time.deltaTime);
            Quaternion wantedRotation = Quaternion.Euler(0, 0, 30);
            model.transform.localRotation = Quaternion.RotateTowards(model.transform.localRotation, wantedRotation, Time.deltaTime * rotationSpeed);
        }



        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            model.transform.rotation = Quaternion.RotateTowards(model.transform.rotation,transform.rotation, Time.deltaTime * rotationSpeed);
        }





    }

    private void FixedUpdate()
    {
        
    }
}
