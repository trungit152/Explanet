using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuSoundSetting : MonoBehaviour
{
    [SerializeField] private Sprite musicOn;
    [SerializeField] private Sprite musicOff;
    [SerializeField] private Image btn;
    public DataSO data;
    void Start()
    {
        btn.sprite = musicOn;
    }

    public void ChangeSprite()
    {
        if (btn.sprite == musicOn)
        {
            btn.sprite = musicOff;
            data.Sound = false;
        }
        else
        {
            btn.sprite = musicOn;
            data.Sound = true;
        }
    }
}
