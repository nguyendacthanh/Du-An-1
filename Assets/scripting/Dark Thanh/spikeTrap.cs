using System;
using System.Collections;
using UnityEngine;

public class spikeTrap : MonoBehaviour
{
    public GameObject player;
    private Animator anim;
    public GameObject panelLost;

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
        anim.SetTrigger("IsDie");
        yield return new WaitForSeconds(1.5f); 
        Destroy(player);
        panelLost.SetActive(true); 
    }
}
