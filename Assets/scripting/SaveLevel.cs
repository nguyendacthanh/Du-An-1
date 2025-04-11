using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLevel : MonoBehaviour
{
    private int currentLevelIndex;

    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        
        if (sceneName.StartsWith("Man"))
        {
            string numberStr = sceneName.Substring(3);
            int.TryParse(numberStr, out currentLevelIndex); 
        }
    }

    public void LevelCompleted()
    {
        PlayerPrefs.SetInt("LastCompletedLevel", currentLevelIndex);
        PlayerPrefs.Save();
    }
}
