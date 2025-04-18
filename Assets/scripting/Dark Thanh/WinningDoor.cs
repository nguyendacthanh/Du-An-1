using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class WinningDoor : MonoBehaviour
{
    public GameObject panelWin;
    private Animator _animator;
    // public GameObject main,LosePanel;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("main"))
        {
            _animator.SetBool("open", true);
            StartCoroutine(ShowWinPanel()); 
        }
    }
    private IEnumerator ShowWinPanel()
    {
        yield return new WaitForSeconds(3f); // Đợi 3 giây
        panelWin.SetActive(true); // Hiện panel
    }
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("bullet"))
    //     {
    //         Destroy(other.gameObject);
    //         Destroy(gameObject);
    //         LosePanel.SetActive(true);
    //         Destroy(main);
    //     }
    //     
    // }
}
