using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class playercontroller : MonoBehaviour
{
    

   
   
    public bool creaturealreadyspawned = false;
    [SerializeField]
    GameObject playerCam;
   
    
    [SerializeField] private enemigovida enemigoVida;
    public CharacterController controller;
    public Transform cam;
    private Animator anim;
    public float speed = 6;
    [SerializeField] private float velocidadcorrer;
    [SerializeField] private float velocidadcaminar;
    public float gravity = -9.81f;
    public float jumpHeight = 3;
    Vector3 velocity;
    bool isGrounded;
    [SerializeField] private bool isRobot;
    public Transform groundCheck;
    public SphereCollider collider;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

   

    public bool isFoucsed = true;
    // Update is called once per frame
    void Start()
    {
        
        anim = GetComponentInChildren<Animator>();
        
    }



    void Update()
    {
        if (isFoucsed==true) { 

        if (Input.GetKeyDown(KeyCode.Mouse0) && creaturealreadyspawned == false)
        {
            StartCoroutine(atacar());
        }
        //jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
            //gravity
            velocity = Vector3.zero;
            velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //walk

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
            //Debug.Log(direction);
            if (direction.magnitude >= 0.1f)
        {
            if (isGrounded)
            {

                Debug.Log(velocity);
                if (velocity != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
                {
                    caminar();
                }
                else if (velocity != Vector3.zero && Input.GetKey(KeyCode.N))
                {
                    correr();
                }
                else if (velocity == Vector3.zero)
                {
                    idle();
                }
                   

            }
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }


    }
    }
    private void idle()
    {
        anim.SetFloat("velocidad", 0, 0.1f, Time.deltaTime);
    }
    private void caminar()
    {
        speed = velocidadcaminar;
        anim.SetFloat("velocidad", 0.5f, 0.1f, Time.deltaTime);
    }
    private void correr()
    {
        speed = velocidadcorrer;
        anim.SetFloat("velocidad", 1f, 0.1f, Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            enemigoVida.recibirDano(10);
        }
    }
    private IEnumerator atacar()
    {
       

        anim.SetLayerWeight(anim.GetLayerIndex("ataque melee"), 1);
        anim.SetTrigger("ataque");
        yield return new WaitForSeconds(0.9f);
        anim.SetLayerWeight(anim.GetLayerIndex("ataque melee"), 0);
        SpawnCreature();
        creaturealreadyspawned = true;
        
    }

    public void SpawnCreature()
    {

        

        /*if(creature.TryGetComponent(out PivotReference reference))
        {
            TransferCamera(reference.pivot);
            this.enabled = false;
        }*/

        //     CinemachineVirtualCamera creaturecamera = CreauretoSpawn.GetComponentInChildren<CinemachineVirtualCamera>();
        //  creaturecam =  creaturecamera  ;


    }
   
}

