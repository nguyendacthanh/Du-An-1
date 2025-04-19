using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public GameObject[] levelButtons;

    void Start()
    {
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelIndex = i + 1;
            
            if (levelIndex <= currentLevel)
            {
                levelButtons[i].SetActive(true);
            }
            else
            {
                levelButtons[i].SetActive(false);
            }
        }
    }
}

