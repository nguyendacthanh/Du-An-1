using System;
using Unity.VisualScripting;
using UnityEngine;

public class readWoodenSignButton : MonoBehaviour
{
    public GameObject panelReadWoodenSign;
   
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("main"))
        {
            panelReadWoodenSign.SetActive(true);
        }
        else
        {
            Debug.Log("không có panel thông báo được ánh xạ");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("main"))
        {
            panelReadWoodenSign.SetActive(false);
        }
        else
        {
            Debug.Log("không có panel thông báo được ánh xạ");
        }
    }
    
}