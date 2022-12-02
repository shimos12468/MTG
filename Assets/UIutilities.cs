using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIutilities : MonoBehaviour
{
    [SerializeField] bool state = false;


    public void changeUIState(int number)
    {
        state = !state;
        for (int i = 0;i<number;i++)
        transform.GetChild(i).transform.gameObject.SetActive(state);
        
    }
}
