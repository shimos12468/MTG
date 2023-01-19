
using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

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

    Vector2 lookInput ,screenCenter ,mouseDistance;


  
    public enum MovmentStates
    {
        OnGround ,
        Flaying ,
        Aiming
    }


    private void Start()
    {
        screenCenter.x = Screen.width * .5f;
        screenCenter.y = Screen.height * .5f;
    }

    void Update()
    {

        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;
        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);


        transform.Rotate(-mouseDistance.x*lookRateSpeed*Time.deltaTime, mouseDistance.x* lookRateSpeed * Time.deltaTime, rollSpeed*rollInput*Time.deltaTime, Space.Self);

        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed ,Input.GetAxisRaw("Vertical") * forwardSpeed,forwardAcceleration*Time.deltaTime);
        activestrafSpeed = Mathf.Lerp(activestrafSpeed,Input.GetAxisRaw("Horizontal") * strafSpeed ,strafeAcceleration*Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed,Input.GetAxisRaw("Hover") * hoverSpeed ,hoverAcceleration*Time.deltaTime);

        transform.position += transform.forward*activeForwardSpeed*Time.deltaTime;
        transform.position += transform.right * activestrafSpeed * Time.deltaTime;
        transform.position += transform.up * activeHoverSpeed * Time.deltaTime;


    }

 

}


