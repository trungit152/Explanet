using UnityEngine;

public class Monster : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private AudioSource monsterDeath;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void DestroyMonster()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            monsterDeath.Play();
            anim.SetTrigger("death");
        }
    }
}
