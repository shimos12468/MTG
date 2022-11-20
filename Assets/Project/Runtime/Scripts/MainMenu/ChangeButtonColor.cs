using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonColor : MonoBehaviour
{
    public Color activeColor, notActiveColor;
    private Image thisImage;

    void Awake()
    {
        thisImage = GetComponent<Image>();
    }

    public void OnPointerClick()
    {
        Activate();
    }

    public void OnPointerEnterAndDown()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Activate();
        }
    }

    public void OnPointerExit()
    {
        thisImage.color = notActiveColor;
    }

    private void Activate()
    {
        
        thisImage.color = activeColor;
    }
}
