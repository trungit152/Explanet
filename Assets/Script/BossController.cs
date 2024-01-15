using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{   
    public float speed = 2.5f;
    public int bossHealth = 5;

    public GameObject player;
    private SpriteRenderer sprite;
    private Animator anim;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed* Time.deltaTime);
        if(transform.position.x > player.transform.position.x)
        {
            sprite.flipX = true;
        }
        else if(transform.position.x < player.transform.position.x)
        {
            sprite.flipX = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && bossHealth > 1)
        {
            bossHealth -= 1;
            anim.SetTrigger("hit");
        }
        else if(collision.gameObject.CompareTag("Bullet") && bossHealth == 1)
        {
            anim.SetTrigger("death");
        }
    }
    public void Victory()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    private void BossDestroy()
    {
        Destroy(gameObject);
    }
}
