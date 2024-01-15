using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSoundSettings : MonoBehaviour
{
    [SerializeField] private AudioSource BGSound;
    public DataSO data;

    void Update()
    {
        if(data.Sound == true)
        {
            BGSound.mute = false;
        }
        if (data.Sound == false)
        {
            BGSound.mute = true;
        }
    }
}
