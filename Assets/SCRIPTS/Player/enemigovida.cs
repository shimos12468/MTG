using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigovida : VIDABASE
{
    private BoxCollider bxcollider;
    // Start is called before the first frame update

    void Awake() {
        bxcollider = GetComponent<BoxCollider>();
    }

    protected override  void Start()
    {
        base.Start();
    }
   
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
