using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspawner : MonoBehaviour
{
    public List<GameObject> spawningObjects = new List<GameObject>();
    public int timeTillMeteor;
    public int maxTime = 10;
    public int limit = 5;
    public int numOfSpawnedCreatures = 0;
    public float currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        timeTillMeteor = Random.Range(0, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (limit > numOfSpawnedCreatures)
        {


            currentTime += Time.deltaTime;
            if (currentTime >= timeTillMeteor)
            {

                Instantiation();
            }
        }
    }


    void Instantiation()
    {
        numOfSpawnedCreatures++;
        int index = Random.Range(0, spawningObjects.Count);
        float x = Random.Range(-10f, 10f);
        float z = Random.Range(-10f, 10f);
        GameObject enemy=  Instantiate(spawningObjects[index], gameObject.transform);
        enemy.transform.position = new Vector3(transform.position.x+x,transform.position.y,transform.position.z+z);
        timeTillMeteor = Random.Range(0, maxTime);
        currentTime = 0;
    }
}
