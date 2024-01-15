using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DropBananaText : MonoBehaviour
{
    [SerializeField] private Text dropBananaText;
    private Animator anim;
    public static DropBananaText Instance;

    public void Awake()
    {
        Instance= this;
    }
    void Start()
    {
        anim= GetComponent<Animator>();
        dropBananaText.text = "Press 'Z' to drop Banana";
    }
    public void ShowNoti()
    {
        anim.SetTrigger("canDrop");
    }
}
