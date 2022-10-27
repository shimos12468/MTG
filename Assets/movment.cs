using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class movment : MonoBehaviour
{
    [SerializeField]
    public float speed = 0;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject startPoint;
    Rigidbody rb;
    bool isGrounded = true;
    public Vector3 jump;
    public float jumpForce = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = true;
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * speed);
           
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 2f, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -2f, 0);
        }

        if (Input.GetMouseButtonDown(0))
        {
            bullet.GetComponent<enemy>().TakeDamage(10);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.tag);
    }
}
