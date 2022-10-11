using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PERSONAJE_MOVIMIENTO : MonoBehaviour
{
    [SerializeField] private float velocidad;

    public bool enMovimiento => dirMov.magnitude > 0f;
    public Vector2 Dirmov
    {
        get
        {
            return dirMov;
        }
    }
    private Rigidbody2D RigidBody2D1;
    private Vector2 input1;
    private Vector2 dirMov;
    private void Awake()
    {
        RigidBody2D1 = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        input1 = new Vector2(x:Input.GetAxisRaw("Horizontal"), y:Input.GetAxisRaw("Vertical"));

        //x
        if(input1.x > 0.1f)
        {
            dirMov.x = 1f;
        }
        else if (input1.x < 0f)
        {
            dirMov.x = -1f;
        }
        else
        {
            dirMov.x = 0f;
        }



        //y

        if (input1.y > 0.1f)
        {
            dirMov.y = 1f;
        }
        else if (input1.y < 0f)
        {
            dirMov.y = -1f;
        }
        else
        {
            dirMov.y = 0f;
        }
    }
    private void FixedUpdate()
    {
        RigidBody2D1.MovePosition(RigidBody2D1.position + dirMov * velocidad * Time.fixedDeltaTime);
    }
}
