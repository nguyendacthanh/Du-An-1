using System;
using Unity.VisualScripting;
using UnityEngine;

public class WinningDoor : MonoBehaviour
{
    public GameObject panelWin;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("main"))
        {
            panelWin.SetActive(true);
        }
    }
}
