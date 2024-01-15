using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private bool isGround = true;

    public static PlayerMovement Instance;

    public DataSO data;

    public float moveSpeed;
    public float jumpForce;
    public float shootTimeCooldown = 2f;
    public float lastShootTime = 0f;
    private float downForce;
    private bool canSpawnBoss = true;
    private int jumped = 0;
    private float horizontal = 0f;
    private SpriteRenderer sprite;
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    public GameObject spawnBossPos;

    [SerializeField] private AudioSource jumpSoundEffect;
    public void Awake()
    {
        Instance= this;
    }
    public bool CanShoot()
    {
        return (Time.time - lastShootTime >= shootTimeCooldown && data.canShoot);
    }
    private enum MovementState { idle, running, jumping, falling };
    void Start()
    {
        Time.timeScale = 1;
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        moveSpeed = data.moveSpeed;
        jumpForce = data.jumpForce;
        downForce = -data.jumpForce * 30;
    }

    void Update()
    {
        
        if (!anim.GetBool("isDeath"))
        {
            isGround = IsGround();
            if (!data.canDoubleJump) 
            {
                Jump();
            }
            else
            {
                DoubleJump();
            }
            MovePressed();
            Shoot();
            GetDown();
        }
        UpdateAnimation();
    }
    private void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Z) && CanShoot()) 
        {
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            lastShootTime = Time.time;
        }
    }
    private void Jump()
    {
        if ((Input.GetKeyDown("space") || Input.GetKeyDown(KeyCode.W)) && isGround)
        {
            //isGround = false;
            //rb.AddForce(Vector2.up * jumpForce);
            if (data.SFX == true)
            {
                jumpSoundEffect.Play();
            }
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    private void DoubleJump()
    {
        if ((Input.GetKeyDown("space") || Input.GetKeyDown(KeyCode.W)) && jumped < 1)
        {
            //isGround = false;
            //rb.AddForce(Vector2.up * jumpForce);
            if (data.SFX == true)
            {
                jumpSoundEffect.Play();
            }
            ++jumped;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);        
        }
        if (isGround)
        {
            jumped = 0;
        }
    }
    //private void OnCollisionStay2D(Collision2D col)
    //{
    //    if (col.gameObject.CompareTag("Terrain"))
    //    {
    //        isGround = true;
    //        jumped = 0;
    //    }
    //}


    private bool IsGround()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, groundLayer);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("BossSpawnPos") && canSpawnBoss)
        {

            BossNoti.Instance.NoWeaponNoti();
            BossSpawnController.Instance.BossSpawn();
            canSpawnBoss = false;
        }
    }
    private void MovePressed()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        //Vector2 movement = new Vector2(horizontal, 0) * moveSpeed * Time.deltaTime;
        //transform.Translate(movement);

        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
    }
    private void GetDown()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            Vector2 down = new Vector2(0f, downForce);
            rb.AddForce(down);
        }
    }
    private void UpdateAnimation()
    {
        MovementState state;
        if (horizontal < 0)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else if (horizontal > 0)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else
        {
            state = MovementState.idle;
        }
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }
}
