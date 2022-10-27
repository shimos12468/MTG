using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public GameObject prefab;
    private Transform target;
    public int count;
    public float speed;
    public bool MakeGarbage;

    private GameObject[] cubes;
    private Vector3[] velocities;

    public bool finished = false;
    public bool once = false;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        cubes = new GameObject[count];
        velocities = new Vector3[count];

        for(int i= 0; i < cubes.Length; i++)
        {
            cubes[i] = Instantiate(prefab);
            cubes[i].transform.SetParent(transform);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x ,0 ,target.position.z), speed * Time.deltaTime);

        if (finished)
            Destroy(this.gameObject);

        for(int i = 0; i < cubes.Length; i++)
        {
            var cubesTrans = cubes[i].transform;
            
            var cubeVel = velocities[i];

            var acc = Random.insideUnitSphere * Time.deltaTime * 1;
            


            if (cubesTrans.position.magnitude > 12f)
            {
                acc = cubesTrans.position.normalized * -acc.magnitude;
                cubeVel *= -0.998f;

            }

            cubeVel += acc;
            cubesTrans.position += cubeVel;
            velocities[i] = cubeVel;
        }


        if (!once)
        {
            once = true;
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        finished = true;
    }
}
