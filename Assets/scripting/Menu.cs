using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private const string LEVEL_KEY = "LastCompletedLevel";

    public void PlayGame()
    {
        int lastLevel = PlayerPrefs.GetInt(LEVEL_KEY, 1);
        SceneManager.LoadScene("Man" + lastLevel);
    }

    public void OpenLevelSelection()
    {
        SceneManager.LoadScene("Level");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

