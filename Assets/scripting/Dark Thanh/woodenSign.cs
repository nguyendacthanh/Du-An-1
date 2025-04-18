using TMPro;
using UnityEngine;

public class woodenSign : MonoBehaviour
{
    public TextMeshProUGUI tmp1; // TextMeshPro để hiển thị nội dung
    public GameObject tmp2; // GameObject chứa TextMeshProUGUI cần hiển thị

    void Start()
    {
        if (tmp1 != null && tmp2 != null)
        {
            TextMeshProUGUI tmp2Text = tmp2.GetComponent<TextMeshProUGUI>();
            if (tmp2Text != null)
            {
                tmp1.text = tmp2Text.text; // Lấy nội dung của tmp2 và hiển thị lên tmp1
            }
            else
            {
                Debug.LogError("tmp2 không chứa TextMeshProUGUI!");
            }
        }
    }
}
