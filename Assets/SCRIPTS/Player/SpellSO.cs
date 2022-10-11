using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Spell")]
public class SpellSO : ScriptableObject
{
    public float Lifetime = 2f;
    public float Speed = 15f;
    public float DamageAmount = 10f;
    public float SpellRadius = 0.5f;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
