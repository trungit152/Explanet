using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    public GameObject HelpPanel;
    public void Help()
    {
        HelpPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Continue()
    {
        HelpPanel.SetActive(false);
        Time.timeScale = 1;
    }

}
