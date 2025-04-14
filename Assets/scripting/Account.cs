using UnityEngine;
using TMPro;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine.UI; // Cho Toggle

public class Account : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TMP_Text messageText;
    public TMP_Text modeText;
    public Toggle showPasswordToggle; // Toggle để ẩn/hiện mật khẩu

    private string filePath;

    void Start()
    {
        filePath = Application.dataPath + "/Account/account.txt";

        string folder = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        if (!File.Exists(filePath))
            File.WriteAllText(filePath, "");

        modeText.text = "ĐăngNhập";

        // Thiết lập mặc định là ẩn mật khẩu
        passwordInput.contentType = TMP_InputField.ContentType.Password;
        passwordInput.ForceLabelUpdate();

        // Lắng nghe toggle
        showPasswordToggle.onValueChanged.AddListener(delegate { TogglePasswordVisibility(); });
    }

    void TogglePasswordVisibility()
    {
        passwordInput.contentType = showPasswordToggle.isOn
            ? TMP_InputField.ContentType.Standard
            : TMP_InputField.ContentType.Password;
        passwordInput.ForceLabelUpdate();
    }

    public void OnRegisterClick()
    {
        modeText.text = "ĐăngKý";
        string username = usernameInput.text.Trim();
        string password = passwordInput.text.Trim();

        // Kiểm tra thông tin
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            messageText.text = "Vui lòng nhập đầy đủ thông tin.";
            return;
        }

        if (ContainsWhitespace(username) || ContainsWhitespace(password))
        {
            messageText.text = "Tài khoản/mật khẩu không được chứa khoảng trắng.";
            return;
        }

        if (!IsAsciiOnly(password))
        {
            messageText.text = "Mật khẩu chỉ dùng ký tự không dấu, không chứa ký tự đặc biệt Unicode.";
            return;
        }

        if (password.Length < 5)
        {
            messageText.text = "Mật khẩu phải có ít nhất 5 ký tự.";
            return;
        }

        // Kiểm tra trùng tài khoản
        string[] lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            string[] parts = line.Split('\t');
            if (parts[0] == username)
            {
                messageText.text = "Tên tài khoản đã tồn tại.";
                return;
            }
        }

        File.AppendAllText(filePath, username + "\t" + password + "\t1\n");
        messageText.text = "Đăng ký thành công!";
    }

    public void OnLoginClick()
    {
        modeText.text = "ĐăngNhập";
        string username = usernameInput.text.Trim();
        string password = passwordInput.text.Trim();

        if (ContainsWhitespace(username) || ContainsWhitespace(password))
        {
            messageText.text = "Tài khoản/mật khẩu không được chứa khoảng trắng.";
            return;
        }

        string[] lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            string[] parts = line.Split('\t');
            if (parts.Length >= 3 && parts[0] == username && parts[1] == password)
            {
                int level = int.Parse(parts[2]);
                messageText.text = "Đăng nhập thành công! Màn: " + level;

                PlayerPrefs.SetString("CurrentUser", username);
                PlayerPrefs.SetInt("CurrentLevel", level);

                gameObject.SetActive(false);
                return;
            }
        }

        messageText.text = "Sai tài khoản hoặc mật khẩu.";
    }

    // Helper: kiểm tra có khoảng trắng
    bool ContainsWhitespace(string input)
    {
        return input.Contains(" ");
    }

    // Helper: kiểm tra có dùng ký tự không phải ASCII (dấu, unicode)
    bool IsAsciiOnly(string input)
    {
        return Regex.IsMatch(input, @"^[\x20-\x7E]+$");
    }
    public void SaveProgress(int newLevel)
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
                parts[2] = newLevel.ToString(); // Cập nhật level
                lines[i] = string.Join("\t", parts);
                break;
            }
        }

        File.WriteAllLines(filePath, lines);
    }
}

