using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectIdentityComponant : MonoBehaviour
{
    private GameObject Object { get; set; }

    public void Onclicked()
    {
        menu.Object?.Invoke(Object);   
    }

    public void SetObject(GameObject obj)
    {
        this.Object = obj;
    }
}
