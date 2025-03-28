using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void Start()
    {
        // Chỉ lưu màn chơi nếu không phải ở menu
        if (SceneManager.GetActiveScene().name != "Menu")
        {
            PlayerPrefs.SetString("LastPlayedLevel", SceneManager.GetActiveScene().name);
            PlayerPrefs.Save();
        }
    }

    public void PlayGame()
    {
        if (PlayerPrefs.HasKey("LastPlayedLevel"))
        {
            string lastLevel = PlayerPrefs.GetString("LastPlayedLevel");

            // Nếu màn đã lưu là MainMenu thì load màn mặc định
            if (lastLevel == "Menu")
            {
                SceneManager.LoadScene("GameScene"); 
            }
            else
            {
                SceneManager.LoadScene(lastLevel);
            }
        }
        else
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    public void OpenLevelSelection()
    {
         SceneManager.LoadScene("LevelSelectionScene");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game exited");
    }
}

