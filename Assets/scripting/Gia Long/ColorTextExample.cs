using TMPro;
using UnityEngine;

public class ColorTextExample : MonoBehaviour
{
    public TMP_Text textToColor;
    public float changeInterval = 0.3f;

    void Start()
    {
        InvokeRepeating("ChangeColor", 0f, changeInterval);
    }

    void ChangeColor()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value);
        textToColor.color = randomColor;
    }
}
