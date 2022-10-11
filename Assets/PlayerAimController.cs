using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimController : MonoBehaviour
{
    //public PlayerMovementInputController input;
    
    public GameObject mainCamera;
    public GameObject aimCamera;
    public GameObject aimReticle;

    public GameObject follow2;
    public GameObject follow1;
    // Start is called before the first frame update
    void Start()
    {
        //input = GetComponent<PlayerMovementInputController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(input.aimValue);
        if (Input.GetMouseButton(1) && !aimCamera.activeInHierarchy)
        {
            mainCamera.SetActive(false);
            aimCamera.SetActive(true);

            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(follow2.transform.position, follow2.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                
            }

           
            StartCoroutine(ShowReticle());
        }
        else if(!Input.GetMouseButton(1) && !mainCamera.activeInHierarchy)
        {
            mainCamera.SetActive(true);
            aimCamera.SetActive(false);
            aimReticle.SetActive(false);
            
            //input.followTransform = follow1;
        }
        
    }

    IEnumerator ShowReticle()
    {
        yield return new WaitForSeconds(0.25f);
        aimReticle.SetActive(enabled);
    }
}
