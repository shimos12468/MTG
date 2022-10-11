using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorplayer : MonoBehaviour
{
    [SerializeField] private float velocidadmov;
    [SerializeField] private float velocidadcorrer;
    [SerializeField] private float velocidadcaminar;
    private Vector3 dirmov;
    private Vector3 velocidad;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float GroundCheckDistance;
    [SerializeField] private LayerMask Groundmask;
    [SerializeField] private float gravedad;
    [SerializeField] private float alturadesalto;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public Transform cam;
    private CharacterController controller;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moverse();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(atacar());
        }
    }
    private void moverse()
    {
       isGrounded = Physics.CheckSphere(transform.position, GroundCheckDistance, Groundmask);
        if(isGrounded && velocidad.y < 0)
        {
            velocidad.y = -2f;
        }
        float Vertical =  Input.GetAxisRaw("Vertical");
        float Horizontal = Input.GetAxisRaw("Horizontal");
        dirmov = new Vector3(Horizontal, 0,Vertical).normalized;
        dirmov = transform.TransformDirection(dirmov);
        if (isGrounded)
        {
            if (dirmov != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                caminar();
            }
            else if (dirmov != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                correr();
            }
            else if (dirmov == Vector3.zero)
            {
                idle();
            }
            dirmov *= velocidadmov;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                saltar();
            }
        }

        if(dirmov.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(dirmov.x, dirmov.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 dir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(dirmov * Time.deltaTime);
            velocidad.y += gravedad * Time.deltaTime;
            controller.Move(velocidad * Time.deltaTime);
        }
       
        
    }
    private void idle()
    {
        anim.SetFloat("velocidad", 0, 0.1f, Time.deltaTime);
    }
    private void caminar()
    {
        velocidadmov = velocidadcaminar;
        anim.SetFloat("velocidad", 0.5f, 0.1f, Time.deltaTime);
    }
    private void correr()
    {
        velocidadmov = velocidadcorrer;
        anim.SetFloat("velocidad", 1f,0.1f,Time.deltaTime);
    }
    private void saltar()
    {
        velocidad.y = Mathf.Sqrt(alturadesalto * -2 * gravedad);

        
    }
    private IEnumerator atacar()
    {
        anim.SetLayerWeight(anim.GetLayerIndex("ataque melee"), 1);
        anim.SetTrigger("ataque");
        yield return new WaitForSeconds(0.9f);
        anim.SetLayerWeight(anim.GetLayerIndex("ataque melee"), 0);
    }
}
