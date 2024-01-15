using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public DataSO data;
    private void Start()
    {
        data.cherries = 0;
        data.jumpForce = 3.8f;
        data.moveSpeed = 3f;
        data.time = 10;
        data.jumpForceLevel = 1;
        data.moveSpeedLevel = 1;
        data.timeLevel= 1;
        data.cost = 10;
        data.canDoubleJump = false;
        data.canShoot= false;
        data.playerHealth = 1;
        data.playerHealthCost = 50;
        data.SFX = true;
        data.Sound = true;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
