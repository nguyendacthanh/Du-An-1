using UnityEngine;
using TMPro;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public GameObject accountListPanel;       
    public Transform accountListContent;      
    public GameObject accountItemPrefab;      

    private string filePath;

    void Start()
    {
        filePath = Application.dataPath + "/Account/account.txt";
        
        string folder = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        if (!File.Exists(filePath))
            File.WriteAllText(filePath, "");

        ShowLeaderboard();
    }
    
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
        
        accountDataList = accountDataList.OrderByDescending(a => a.level).ToList();
        
        foreach (Transform child in accountListContent)
        {
            Destroy(child.gameObject);
        }

        int rank = 1;
        int displayRank = 1;
        int? lastLevel = null;

        foreach (var account in accountDataList)
        {
            if (lastLevel != null && account.level != lastLevel)
            {
                displayRank = rank;
            }

            GameObject accountItem = Instantiate(accountItemPrefab, accountListContent);
            TMP_Text[] texts = accountItem.GetComponentsInChildren<TMP_Text>();

            if (texts.Length >= 1)
            {
                texts[0].text = $"#{displayRank}. {account.username} / Level: {account.level}";
            }

            lastLevel = account.level;
            rank++;
        }

        accountListPanel.SetActive(true);
    }
    
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
            newLines.Add(account.username + "\t12345\t" + account.level);
        }

        File.WriteAllLines(filePath, newLines);

        ShowLeaderboard();
    }
}

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




