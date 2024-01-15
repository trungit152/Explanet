using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    private float timeCounter = 0f;
    private bool isStatic = false;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        timeCounter+= Time.deltaTime;
        if(timeCounter >= 2 && !isStatic)
        {
            rb.bodyType = RigidbodyType2D.Static;
            isStatic = true;
        }
    }
}
