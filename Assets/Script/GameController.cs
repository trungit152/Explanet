using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Text timeText;
    private float time = 5f;
    float timeCounter = 0f;
    [SerializeField] private GameObject player;
    void Start()
    {
        timeText.text = "" + time;
    }
    void Update()
    {
        if (time > 0)
        {
            TimeCounter();
        }
    }
    private void TimeCounter()
    {
        timeCounter += Time.deltaTime;
        {
            if (timeCounter >= 1f)
            {
                time -= 1;
                timeText.text = "" + time;
                timeCounter = 0f;
            }
        }
    }
}
