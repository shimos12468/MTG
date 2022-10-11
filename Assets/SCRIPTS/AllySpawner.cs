using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllySpawner : MonoBehaviour
{
    public VIDABASE vIDABASE;
    private int soul;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        soul = vIDABASE.soul;
    }
}
