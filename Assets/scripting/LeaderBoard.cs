using UnityEngine;
using TMPro;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public GameObject accountListPanel;       // Panel chứa danh sách tài khoản
    public Transform accountListContent;      // Content của ScrollView
    public GameObject accountItemPrefab;      // Prefab cho mỗi tài khoản

    private string filePath;

    void Start()
    {
        filePath = Application.dataPath + "/Account/account.txt";

        // Kiểm tra và tạo thư mục nếu chưa có
        string folder = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        if (!File.Exists(filePath))
            File.WriteAllText(filePath, "");

        ShowLeaderboard();
    }

    // Hiển thị bảng xếp hạng
    public void ShowLeaderboard()
    {
        string[] lines = File.ReadAllLines(filePath);
        List<AccountData> accountDataList = new List<AccountData>();

        foreach (var line in lines)
        {
            string[] parts = line.Split('\t');
            if (parts.Length >= 3)
            {
                string username = parts[0];
                int level;
                if (int.TryParse(parts[2], out level))
                {
                    accountDataList.Add(new AccountData(username, level));
                }
            }
        }

        // Sắp xếp theo level giảm dần
        accountDataList = accountDataList.OrderByDescending(a => a.level).ToList();

        // Xóa mục cũ
        foreach (Transform child in accountListContent)
        {
            Destroy(child.gameObject);
        }

        // Tạo mục mới với xếp hạng
        int rank = 1;
        foreach (var account in accountDataList)
        {
            GameObject accountItem = Instantiate(accountItemPrefab, accountListContent);
            TMP_Text[] texts = accountItem.GetComponentsInChildren<TMP_Text>();

            if (texts.Length >= 3)
            {
                texts[0].text = "#" + rank.ToString();                // Rank
                texts[1].text = account.username;                     // Username
                texts[2].text = "Level: " + account.level.ToString(); // Level
            }

            rank++;
        }

        accountListPanel.SetActive(true);
    }

    // Thêm tài khoản mới
    public void AddNewAccount(string username, int level)
    {
        string[] lines = File.ReadAllLines(filePath);
        List<AccountData> accountDataList = new List<AccountData>();

        foreach (var line in lines)
        {
            string[] parts = line.Split('\t');
            if (parts.Length >= 3)
            {
                accountDataList.Add(new AccountData(parts[0], int.Parse(parts[2])));
            }
        }

        accountDataList.Add(new AccountData(username, level));
        accountDataList = accountDataList.OrderByDescending(a => a.level).ToList();

        List<string> newLines = new List<string>();
        foreach (var account in accountDataList)
        {
            // Nếu muốn giữ lại password, bạn có thể ghi thêm chỗ này
            newLines.Add(account.username + "\t12345\t" + account.level); // dummy password
        }

        File.WriteAllLines(filePath, newLines);

        ShowLeaderboard();
    }
}

// Class lưu thông tin tài khoản
public class AccountData
{
    public string username;
    public int level;

    public AccountData(string username, int level)
    {
        this.username = username;
        this.level = level;
    }
}




