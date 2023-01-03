using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;

public class character_controler : MonoBehaviour
{


    public CinemachineFreeLook freelookCam;
    public static character_controler Instance;
    public CharacterController controler;
    public Transform cam;
    public Transform direction;
    public Animator anim;
    public float turnSmoothTime = 0.1f;
    public float runningSpeed;
    public float walkSpeed;
    public TMP_Text selectionText;
    float turnsmoothvelocity;
    public float speed = 6f;
    public bool isFoucsed = true;
    private bool increase, decrease;
    public float jumpforce = 100;
    public float gravity = 10f;
    private bool creaturealreadyspawned = false;
    public static Action<bool, bool> changeselectedItem;

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

        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        isFoucsed = true;

    }

    void Update()
    {



        if (isFoucsed)
        {

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            CaptureEnemy();

            if (Input.GetMouseButtonDown(1))
            {
                idle();

                StartCoroutine(atacar());


            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                idle();

                StartCoroutine(Capture());


            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                increase = true;
                decrease = false;
                changeselectedItem?.Invoke(increase, decrease);
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                increase = false;
                decrease = true;
                changeselectedItem?.Invoke(increase, decrease);




            }
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;
            float screenX = Screen.width;
            float screenY = Screen.height;

            if (Input.GetMouseButton(0) && !(mouseX < 0 || mouseX > screenX || mouseY < 0 || mouseY > screenY))
            {
                freelookCam.m_XAxis.m_MaxSpeed = 100;

            }
            if (!Input.GetMouseButton(0))
            {
                freelookCam.m_XAxis.m_MaxSpeed = 0;
                freelookCam.m_YAxis.m_MaxSpeed = 0;
            }


            if (direction.magnitude >= 0.1f)
            {

                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnsmoothvelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;


                if (Input.GetKey(KeyCode.N))
                {
                    correr();
                    speed = runningSpeed;


                }

                else
                {
                    caminar();
                    speed = walkSpeed;

                }
                controler.SimpleMove(moveDir.normalized * speed * Time.deltaTime);
            }
            else
            {
                idle();


            }
        }

    }

    private void CaptureEnemy()
    {
        RaycastHit hit;
        if (Physics.Raycast(direction.transform.position, direction.transform.TransformDirection(Vector3.forward), out hit, 100))
        {
            if (hit.collider.tag == "DeadEnemy")
            {
                GameObject enemy = hit.collider.gameObject.GetComponent<collectcreture>().GetPrefab();
                hit.collider.gameObject.GetComponent<collectcreture>().DestroyEnemy();
                creatuers_spawn.instance.creatures.Add(enemy);
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



    private IEnumerator Capture()
    {
        Debug.Log("capture");
        //creaturealreadyspawned = true;
        anim.SetLayerWeight(anim.GetLayerIndex("Capture"), 1);
        anim.SetTrigger("Capture");
        yield return new WaitForSeconds(5f);
        anim.SetLayerWeight(anim.GetLayerIndex("Capture"), 0);
    }
    private void SpawnCreature()
    {

        transform.gameObject.GetComponent<creatuers_spawn>().spawncreature();
    }



}
