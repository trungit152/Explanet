using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public DataSO data;
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private Text timeText;
    [SerializeField] private Text helthText;
    public float time;
    float timeCounter = 0f;
    private int playerHealth;
    private float invisibleTime = 1f;
    private bool isTimeUp = false;

    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private AudioSource hitSoundEffect;
    [SerializeField] private AudioSource timeUpEffect;
    void Start()
    {
        time = data.time;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        timeText.text = "" + time;
        playerHealth = data.playerHealth;
        helthText.text = "Health :" + playerHealth;

    }
    private void Update()
    {
        if (!anim.GetBool("isDeath"))
        {
            if (invisibleTime > 0)
            {
                invisibleTime -= Time.deltaTime;
            }
            helthText.text = "Health :" + playerHealth;
            if (time < 6 && isTimeUp == false)
            {
                if(data.SFX == true)
                {
                    timeUpEffect.Play();
                }
                isTimeUp = true;
            }
            if (time > 0)
            {
                TimeCounter();
            }
            else
            {
                if(data.SFX == true)
                {
                    deathSoundEffect.Play();
                }
                anim.SetTrigger("death");
                anim.SetBool("isDeath", true);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        if ((col.gameObject.CompareTag("Trap") || col.gameObject.CompareTag("Monster") || col.gameObject.CompareTag("Boss")) 
            && playerHealth <= 1 && invisibleTime <= 0 && !anim.GetBool("isDeath"))
        {
            helthText.text = "Health :0";
            Die();
        }
        else if (col.gameObject.CompareTag("DeadZone") && !anim.GetBool("isDeath"))
        {
            Die();
        }
        else if((col.gameObject.CompareTag("Trap") || col.gameObject.CompareTag("Monster") || col.gameObject.CompareTag("Boss")) && playerHealth > 1 && invisibleTime <= 0)
        {
            anim.SetTrigger("hit");
            Hit();
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if ((col.gameObject.CompareTag("Trap") || col.gameObject.CompareTag("Monster")) 
            && playerHealth <= 1 && invisibleTime <= 0 && !anim.GetBool("isDeath"))
        {
            helthText.text = "Health :0";
            Die();
        }
        else if ((col.gameObject.CompareTag("Trap") || col.gameObject.CompareTag("Monster")) 
            && playerHealth > 1 && invisibleTime <= 0)
        {
            anim.SetTrigger("hit");
            Hit();
        }
    }

    public void Hit()
    {
        if (data.SFX == true)
        {
            hitSoundEffect.Play();
        }
        Vector3 hit = new Vector2(200f, 200f);
        rb.AddForce(hit);
        anim.SetTrigger("hit");
        playerHealth -= 1;
        invisibleTime = 1f;
    }
    public void Die()
    {
        if (data.SFX == true)
        {
            deathSoundEffect.Play();
        }
        anim.SetTrigger("death");
        anim.SetBool("isDeath", true);
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void GoToUpgrade()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
