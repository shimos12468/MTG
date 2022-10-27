using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyV2 : MonoBehaviour
{
    public enum States
    {
        Roaming,
        Attacking ,
        Chasing,
        Nothing

    }

    public enum Actions{
       Near,
       Far,
       Arange,
       Nostamina
    }
    public List<Actions> actions = new List<Actions> {Actions.Near ,Actions.Far ,Actions.Arange ,Actions.Nostamina };
   

    Vector3 startingPosition;
    void Start()
    {
        startingPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Vector3 GetRoamingPosition()
    {
        return startingPosition + GetRandomDirection()* Random.Range(10f, 70f);

    }

    public Vector3 GetRandomDirection()
    {
        return new Vector3(UnityEngine.Random.Range(1f,1f) , UnityEngine.Random.Range(1f, 1f)).normalized;
    }
}
