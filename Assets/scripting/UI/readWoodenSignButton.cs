using System;
using Unity.VisualScripting;
using UnityEngine;

public class readWoodenSignButton : MonoBehaviour
{
    public GameObject panelReadWoodenSign;
    public GameObject ButtonRead;

    public void setActiveReadWoodenSignOpen()
    {
        if (panelReadWoodenSign != null)
        {
            panelReadWoodenSign.SetActive(true);
            ButtonRead.SetActive(false);
        }
        else
        {
            Debug.Log("không có panel thông báo được ánh xạ");
        }
    }
    public void setActiveReadWoodenSignClose()
    {
        if (panelReadWoodenSign != null)
        {
            panelReadWoodenSign.SetActive(false);
            ButtonRead.SetActive(true);
        }
        else
        {
            Debug.Log("không có panel thông báo được ánh xạ");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("main"))
        {
            ButtonRead.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("main"))
        {
            ButtonRead.SetActive(false);
        }
    }
    
}
