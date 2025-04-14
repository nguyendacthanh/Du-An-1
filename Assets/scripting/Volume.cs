using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Button soundToggleButton;
    public Sprite soundOnIcon;
    public Sprite soundOffIcon;

    private bool isMuted;

    private void Start()
    {
        isMuted = PlayerPrefs.GetInt("Muted", 0) == 1;
        UpdateSound();

        soundToggleButton.onClick.AddListener(ToggleSound);
    }

    void ToggleSound()
    {
        isMuted = !isMuted;
        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
        UpdateSound();
    }

    void UpdateSound()
    {
        AudioListener.volume = isMuted ? 0 : 1;
        soundToggleButton.image.sprite = isMuted ? soundOffIcon : soundOnIcon;
    }
}
