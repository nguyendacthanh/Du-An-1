using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    private const string LEVEL_KEY = "LastCompletedLevel";

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void NextLevel()
    {
        int nextLevel = PlayerPrefs.GetInt(LEVEL_KEY, 1) + 1;
        PlayerPrefs.SetInt(LEVEL_KEY, nextLevel);
        SceneManager.LoadScene("Man" + nextLevel);
        FindObjectOfType<LevelMNG>().OnLevelComplete();
    }
}
