using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHead : MonoBehaviour
{
    private readonly float coolDown = 3f;
    public GameObject bulletPrefab;
    private float lastShootTime = 0f;
    private Animator anim;
    private int spikeHeadHealth = 3;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (CanShoot())
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            lastShootTime = Time.time;
        }
    }
    bool CanShoot()
    {
        return Time.time - lastShootTime >= coolDown;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && spikeHeadHealth > 1)
        {
            spikeHeadHealth -= 1;
            anim.SetTrigger("hit");
        }
        else if (collision.gameObject.CompareTag("Bullet") && spikeHeadHealth == 1)
        {
            anim.SetTrigger("death");
        }
    }
    private void DestroySpikeHead()
    {
        Destroy(gameObject);
    }
}
