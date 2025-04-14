using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject leaderboard;
    public GameObject loginPanel;
    private const string LEVEL_KEY = "LastCompletedLevel";

    public void PlayGame()
    {
        int lastLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        SceneManager.LoadScene("Man" + lastLevel);
    }

    public void OpenLevelSelection()
    {
        SceneManager.LoadScene("Level");
    }

    public void ExitGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Application.Quit();
    }

    public void LoginPanel()
    {
        loginPanel.SetActive(true);
    }
    public void ShowLeaderboardButtonClicked()
    {
        leaderboard.SetActive(true); // Hiển thị bảng xếp hạng khi nhấn nút
    }
}

