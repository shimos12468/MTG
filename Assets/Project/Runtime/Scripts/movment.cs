using System;
using UnityEngine;

public class movment : MonoBehaviour
{


    [SerializeField, Range(1f, 100f)]
    float strafSpeed = 7.5f;
    [SerializeField, Range(1f, 100f)]
    float forwardSpeed = 25f;
    [SerializeField, Range(1f, 100f)]
    float hoverSpeed = 5f;
    
    private float activeForwardSpeed;   
    private float activestrafSpeed;
    private float activeHoverSpeed;

    private float forwardAcceleration = 2.5f;
    private float strafeAcceleration = 2f;
    private float hoverAcceleration = 2f;

    public float lookRateSpeed = 90f;

    private float rollInput;
    public float rollSpeed=90f ,rollAcceleration =3.5f;
    public float sensitivity = 0.5f;
    Vector2 lookInput ,screenCenter ,mouseDistance ,turn;


  
    public enum MovmentStates
    {
        OnGround ,
        Flaying ,
        Aiming
    }


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

       

        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);


       

        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed ,Input.GetAxisRaw("Vertical") * forwardSpeed,forwardAcceleration*Time.deltaTime);
        activestrafSpeed = Mathf.Lerp(activestrafSpeed,Input.GetAxisRaw("Horizontal") * strafSpeed ,strafeAcceleration*Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed,Input.GetAxisRaw("Hover") * hoverSpeed ,hoverAcceleration*Time.deltaTime);






        if (Input.GetKey(KeyCode.W) ||Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.LeftControl))
        {
            turn.x += Input.GetAxis("Mouse X") * sensitivity;
            turn.y += Input.GetAxis("Mouse Y") * sensitivity;
            turn.y = Mathf.Clamp(turn.y, -60f ,60f);
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, transform.localRotation.eulerAngles.z);
            transform.Rotate(0f, 0f, rollSpeed * rollInput * Time.deltaTime, Space.Self);
           
        }

       

        transform.position += transform.forward*activeForwardSpeed*Time.deltaTime;
        transform.position += transform.right * activestrafSpeed * Time.deltaTime;
        transform.position += transform.up * activeHoverSpeed * Time.deltaTime;


    }

 

}


