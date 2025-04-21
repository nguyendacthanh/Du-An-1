using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public void SelectLevel(int levelIndex)
    {
        ClickButton.instance.PlayClickSound(); 
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
        ClickButton.instance.PlayClickSound(); 
        SceneManager.LoadScene("Menu");
    }
}
