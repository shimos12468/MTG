using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDamage : MonoBehaviour
{
    public float Damage = 10;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.GetComponent<Stats>())
            other.gameObject.GetComponent<Stats>().TakeDamage(Damage);

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.GetComponent<Stats>())
        other.gameObject.GetComponent<Stats>().TakeDamage(Damage);
    }
}
