using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LevelMNG : MonoBehaviour
{
    private string filePath;

    void Start()
    {
        filePath = Application.dataPath + "/Account/account.txt";
    }

    public void OnLevelComplete()
    {
        int newLevel = PlayerPrefs.GetInt("CurrentLevel", 1) + 1;

        // Cập nhật PlayerPrefs
        PlayerPrefs.SetInt("CurrentLevel", newLevel);
        PlayerPrefs.SetInt("LastCompletedLevel", newLevel);
        PlayerPrefs.Save();

        SaveProgress(newLevel);

        // Load màn tiếp theo
        SceneManager.LoadScene("Man" + newLevel);
    }

    void SaveProgress(int newLevel)
    {
        string username = PlayerPrefs.GetString("CurrentUser", "");

        if (string.IsNullOrEmpty(username))
            return;

        string[] lines = File.ReadAllLines(filePath);
        for (int i = 0; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('\t');
            if (parts.Length >= 3 && parts[0] == username)
            {
                parts[2] = newLevel.ToString();
                lines[i] = string.Join("\t", parts);
                break;
            }
        }

        File.WriteAllLines(filePath, lines);
    }
}
