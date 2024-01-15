using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject/Data")] 
public class DataSO : ScriptableObject
{
    public int cherries = 0;
    public float moveSpeed = 3f;
    public float jumpForce = 3.8f;
    public int time = 10;
    public int jumpForceLevel = 1;
    public int moveSpeedLevel = 1;
    public int timeLevel = 1;
    public int cost = 10;
    public bool canShoot = false;
    public bool canDoubleJump = false;
    public int doubleJumpCost = 150;
    public int playerHealth = 1;
    public int playerHealthCost = 50;
    public bool SFX = true;
    public bool Sound = true;
}
