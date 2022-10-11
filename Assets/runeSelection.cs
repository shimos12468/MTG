using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runeSelection : MonoBehaviour
{
    private Rune rune;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetselectedRune(Rune item)
    {
        this.rune = item;
    }

    public void sendToPurchesdRune()
    {
        if (rune.unlocked)
        {
            if (rune.level < 3)
            {

                rune.Upgrade();
            }
        }
        else
        {
            rune.Unlock();        }
    }
}
