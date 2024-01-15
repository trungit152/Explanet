using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossNoti : MonoBehaviour
{
    [SerializeField] private Text bossNotiText;
    private Animator anim;
    public static BossNoti Instance;
    public DataSO data;
    private void Awake()
    {
        Instance = this; 
    }
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void NoWeaponNoti()
    {
        if (!data.canShoot)
        {
            bossNotiText.text = "Find a weapon to defeat the Boss\n(What about Banana?)";
            anim.SetTrigger("on");
        }
        else
        {
            bossNotiText.text = "Kill the Boss!!!";
            anim.SetTrigger("on");
        }
    }
}
