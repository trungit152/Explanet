using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeCostText : MonoBehaviour
{
    public DataSO data;
    public int cost = 10;
    [SerializeField] private Text jumpForceCostText;
    [SerializeField] private Text moveSpeedCostText;
    [SerializeField] private Text timeCostText;
    [SerializeField] private Text cherriesText;
    [SerializeField] private Text doubleJumpText;
    [SerializeField] private Text healthText;
    public static UpgradeCostText instance;

    public void Awake()
    {
        instance = this; 
    }
    public void Update()
    {
        JumpForce();
        PlayerHealth();
        MoveSpeed();
        Time();
        DoubleJump();
        HackCherries();
        cherriesText.text = "Cherries :" + data.cherries;
    }
    private void HackCherries()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Alpha6))
        {
            data.cherries += 100;
        }
    }
    public void PlayerHealth()
    {
        if (data.playerHealth >= 10)
        {
            healthText.text = "Max";
        }
        else if (data.playerHealth < 10)
        {
            healthText.text = "Cost :" + data.playerHealthCost;
        }
    }
    public void JumpForce()
    {
        if (data.jumpForceLevel >= 10)
        {
            jumpForceCostText.text = "Max";
        }
        else if (data.jumpForceLevel < 10)
        {
            jumpForceCostText.text = "Cost :" + (cost * data.jumpForceLevel);
        }
    }
    public void MoveSpeed()
    {
        if (data.moveSpeedLevel >= 10)
        {
            moveSpeedCostText.text = "Max";
        }
        else if (data.moveSpeedLevel < 10)
        {
            moveSpeedCostText.text = "Cost :" + (cost * data.moveSpeedLevel);
        }
    }
    public void Time()
    {
        if (data.timeLevel >= 15)
        {
            timeCostText.text = "Max";
        }
        else if (data.timeLevel < 15)
        {
            timeCostText.text = "Cost :" + (cost * data.timeLevel);
        }
    }
    public void DoubleJump()
    {
        if (data.canDoubleJump)
        {
            doubleJumpText.text = "Max";
        }
        else if (!data.canDoubleJump)
        {
            doubleJumpText.text = "Cost :" + data.doubleJumpCost;
        }
    }



}
