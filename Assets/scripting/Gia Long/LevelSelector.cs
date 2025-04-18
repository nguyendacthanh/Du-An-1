using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public GameObject[] levelButtons; // Kéo các button level vào đây từ 1 đến 20

    void Start()
    {
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelIndex = i + 1;

            // Nếu level này nhỏ hơn hoặc bằng level đã mở
            if (levelIndex <= currentLevel)
            {
                levelButtons[i].SetActive(true);
            }
            else
            {
                levelButtons[i].SetActive(false); // hoặc: levelButtons[i].GetComponent<Button>().interactable = false;
            }
        }
    }
}

