using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public void SelectLevel(int levelIndex)
    {
        string sceneName = "Man" + levelIndex;
        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene " + sceneName + " chưa được thêm vào Build Settings!");
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
