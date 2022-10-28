using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class character_controler : MonoBehaviour
{

    public static character_controler Instance;
    public CharacterController controler;
    public Transform cam;
     
    public Animator anim;
    Vector3 velocity;
    public float turnSmoothTime = 0.1f;
    public TMP_Text selectionText;
    float turnsmoothvelocity;
    public float speed = 6f;
    public bool isFoucsed = true;
    float gravity = -9.81f;
    private bool creaturealreadyspawned = false;
  
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        isFoucsed = true;

    }

    // Update is called once per frame
    void Update()
    {

       

        

        if (isFoucsed)
        {
            if ( velocity.y < 0)
            {
                velocity.y = -2f;
            }
            velocity = Vector3.zero;
            velocity.y += gravity * Time.deltaTime;
            controler.Move(velocity * Time.deltaTime);
            //Debug.Log("true");
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;


            if (Input.GetMouseButtonDown(1) && creaturealreadyspawned == false)
            {
                idle();
                
                StartCoroutine(atacar());


            }


            if (direction.magnitude >= 0.1f)
            {




                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnsmoothvelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                //Debug.Log(moveDir);
                controler.SimpleMove(moveDir.normalized * speed * Time.deltaTime);

                if (Input.GetKey(KeyCode.N))
                    correr();
                else
                    caminar();
            }
            else
            {
                idle();

                //idel
            }
        }

    }
    private void idle()
    {
        anim.SetFloat("velocidad", 0, 0.1f, Time.deltaTime);
    }
    private void caminar()
    {
        
        anim.SetFloat("velocidad", 0.5f, 0.1f, Time.deltaTime);
    }
    private void correr()
    {
        
        speed = 14;
        anim.SetFloat("velocidad", 1f, 0.1f, Time.deltaTime);
    }
    private IEnumerator atacar()
    {

        //creaturealreadyspawned = true;
        anim.SetLayerWeight(anim.GetLayerIndex("ataque melee"), 1);
        anim.SetTrigger("ataque");
        yield return new WaitForSeconds(0.9f);
        anim.SetLayerWeight(anim.GetLayerIndex("ataque melee"), 0);
        SpawnCreature();
       


    }

   
    private void SpawnCreature()
    {
       
        transform.gameObject.GetComponent<creatuers_spawn>().spawncreature();
    }

    

}
