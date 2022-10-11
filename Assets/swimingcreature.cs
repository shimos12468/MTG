using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SelectionBase]
public class swimingcreature : MonoBehaviour
{

    private Quaternion qto;

    private Vector3 destination;

    public float speed;

    public float speedToMove;
    public float speedToRotate;

    // Use this for initialization
    void Start()
    {
        destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            destination += Vector3.right * speed * Time.deltaTime; // Set our destination as the desired one
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            destination += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            destination += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            destination += Vector3.down * speed * Time.deltaTime;
        }

        Vector3 target = new Vector3(destination.x - transform.position.x, destination.y - transform.position.y, destination.z - transform.position.z); // Create a new vector relatively to our current position
        qto = Quaternion.LookRotation(target); // Set our rotation destination
                                               // And there we go to the desired destination using Move&RotateTowards()
        transform.position = Vector3.MoveTowards(transform.position, destination, speedToMove * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, qto, speedToRotate * Time.deltaTime);
    }
}
