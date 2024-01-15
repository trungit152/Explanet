using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemsCollector : MonoBehaviour
{
    public DataSO data;
    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioSource collectSoundEffect;

    private void Start()
    {
        cherriesText.text = "Cherries: " + data.cherries;
    }
    private void Update()
    {
        HackCherries();
    }
    private void HackCherries()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Alpha6))
        {
            data.cherries += 100;
            cherriesText.text = "Cherries: " + data.cherries;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            if (data.SFX == true)
            {
                collectSoundEffect.Play();
            }
            data.cherries++;
            cherriesText.text = "Cherries: " + data.cherries;
        }
        if (collision.gameObject.CompareTag("Bananas"))
        {
            if(data.SFX == true)
            {
                collectSoundEffect.Play();
            }
            DropBananaText.Instance.ShowNoti();
            data.canShoot = true;
        }
    }
}
