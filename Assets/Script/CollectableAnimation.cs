using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableAnimation : MonoBehaviour
{
    private enum CherryState { idle, disapear };
    CherryState state = CherryState.idle;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            state = CherryState.disapear;
            anim.SetInteger("state", (int)state);
        }
    }

    private void Destroy()
    {
        GameObject.Destroy(gameObject);
    }
}
