using System;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownController : MonoBehaviour
{
    public DataSO data;
    public Image banana;
    public Text coolDownTime;
    private float cdTime = 0f;
    private void Update()
    {
        if (!data.canShoot)
        {
            banana.enabled= false;
            coolDownTime.text = "";
        }
        else if(data.canShoot)
        {
            banana.enabled= true;
        }

        if (PlayerMovement.Instance != null)
        {
            cdTime = PlayerMovement.Instance.shootTimeCooldown - (Time.time - PlayerMovement.Instance.lastShootTime);
        }

        if (data.canShoot && cdTime > 0)
        {
            coolDownTime.text = "" + Math.Round(cdTime, 1);
            banana.color = Color.grey;
        }
        else if(data.canShoot &&  cdTime <= 0)
        {
            coolDownTime.text = "";
            banana.color = Color.white;
        }
    }
}
