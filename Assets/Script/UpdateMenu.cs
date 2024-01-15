using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UpdateMenu : MonoBehaviour
{
    public DataSO data;

    public void UpgradeJumpForce()
    {
        int total = data.cost * data.jumpForceLevel;
        if (data.cherries >= data.cost * data.jumpForceLevel && data.jumpForceLevel < 10)
        {
            data.cherries -= data.cost * data.jumpForceLevel;
            data.jumpForceLevel+= 1;
            data.jumpForce += 0.4f + data.jumpForceLevel / 10;
            
            //UpgradeCostText.instance.Start();
        }
    }
    public void UpgradeMoveSpeed()
    {
        int total = data.cost * data.moveSpeedLevel;
        if (data.cherries >= data.cost * data.moveSpeedLevel && data.moveSpeedLevel < 10)
        {
            data.cherries -= data.cost * data.moveSpeedLevel;
            data.moveSpeedLevel += 1;
            data.moveSpeed += 0.25f + data.moveSpeedLevel / 10;
            
            //UpgradeCostText.instance.Start();
        }
    }
    public void UpgradeTime()
    {
        int total = data.cost * data.timeLevel;
        if (data.cherries >= data.cost * data.timeLevel && data.timeLevel < 15)
        {
            data.cherries -= data.cost * data.timeLevel;
            data.timeLevel+=1;
            data.time += (6 + data.timeLevel);
            
            //UpgradeCostText.instance.Start();
        }
    }
    public void DoubleJumpUpgrade()
    {
        if (data.cherries >= data.doubleJumpCost && !data.canDoubleJump)
        {
            data.cherries -= data.doubleJumpCost;
            data.canDoubleJump = true;
            //UpgradeCostText.instance.Start();
        }
    }
    public void UpgradeHealth()
    {
        if (data.cherries >= data.playerHealthCost && data.playerHealth < 10)
        {
            data.cherries -= data.playerHealthCost;
            data.playerHealth += 1;
            data.playerHealthCost *= 2;
            //UpgradeCostText.instance.Start();
        }
    }
    public void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}

