using System;
using System.Collections;
using UnityEngine;

public class spikeTrap : MonoBehaviour
{
    public GameObject player;
    private Animator anim;
    public GameObject panelLost;
    public AudioSource audioSource;
    public AudioClip loseSound;

    private void Start()
    {
        anim = player.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("main"))
        {
            StartCoroutine(ShowLostPanel());
        }
    }

    private IEnumerator ShowLostPanel()
    { 
        player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        player.GetComponent<Player>().enabled = false;

        anim.SetTrigger("IsDie");
        
        audioSource.PlayOneShot(loseSound);

        yield return new WaitForSecondsRealtime(1.5f);

        Time.timeScale = 0f;

        Destroy(player);
        panelLost.SetActive(true);
    }
}
