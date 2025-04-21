using UnityEngine;

public class ClickButton : MonoBehaviour
{
    public static ClickButton instance;

    public AudioSource audioSource;
    public AudioClip clickSound;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayClickSound()
    {
        if (clickSound != null)
            audioSource.PlayOneShot(clickSound);
    }
}
