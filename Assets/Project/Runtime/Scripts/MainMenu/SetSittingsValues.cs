using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetSittingsValues : MonoBehaviour
{
    
    public Slider musicVolume;
    public Slider effectsVolume;
    public Slider mouseSensitivity;
    public TMP_Text musicText, effectsText, mouseSensitivityText;
    public AudioSource c;

    public void SetMusicVolume()
    {
        PlayerPrefs.SetFloat("musicVolume", musicVolume.value);
        float m = musicVolume.value;
        c.volume = m;
        c.Play();


        musicText.text = (m*100).ToString("0.0");
    }

    public void SetEffectsVolume()
    {
        PlayerPrefs.SetFloat("effectsVolume", effectsVolume.value);
        effectsText.text = (100*effectsVolume.value).ToString("0.0");
    }

    public void SetMouseSensitivity()
    {
        PlayerPrefs.SetFloat("mouseSensitivity", mouseSensitivity.value);
        mouseSensitivityText.text = (100*mouseSensitivity.value).ToString("0.0");
    }


}
