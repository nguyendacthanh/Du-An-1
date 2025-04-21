using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject leaderboard;
    public GameObject loginPanel;
    private const string LEVEL_KEY = "LastCompletedLevel";

    public void PlayGame()
    {
        ClickButton.instance.PlayClickSound(); 
        int lastLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        SceneManager.LoadScene("Man" + lastLevel);
    }

    public void OpenLevelSelection()
    {
        ClickButton.instance.PlayClickSound(); 
        SceneManager.LoadScene("Level");
    }

    public void ExitGame()
    {
        ClickButton.instance.PlayClickSound(); 
        Application.Quit();
        PlayerPrefs.DeleteKey("CurrentLevel");
    }

    public void LoginPanel()
    {
        ClickButton.instance.PlayClickSound(); 
        loginPanel.SetActive(true);
    }
    public void ShowLeaderboardButtonClicked()
    {
        ClickButton.instance.PlayClickSound(); 
        leaderboard.SetActive(true);
    }
    
}

