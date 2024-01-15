using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public Text SFXText;
    public Text SoundText;
    public DataSO data;

    private void Start()
    {
        if(data.SFX == true)
        {
            SFXText.text = "SFX: On";
        }
        else
        {
            SFXText.text = "SFX: Off";
        }
        if(data.Sound == true)
        {
            SoundText.text = "Sound: On";
        }
        else
        {
            SoundText.text = "Sound: Off";
        }
    }

    public void SFXBtn()
    {
        if (SFXText.text == "SFX: On") 
        {
            SFXText.text = "SFX: Off";
            data.SFX = false;
        }
        else if (SFXText.text == "SFX: Off")
        {
            SFXText.text = "SFX: On";
            data.SFX = true;
        }
    }
    public void SoundBtn()
    {
        if (SoundText.text == "Sound: On")
        {
            SoundText.text = "Sound: Off";
            data.Sound = false;
        }
        else if (SoundText.text == "Sound: Off")
        {
            SoundText.text = "Sound: On";
            data.Sound = true;
        }
    }
}
