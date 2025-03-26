using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class ButtonKey : MonoBehaviour
{
    // demo thu git jjjjj
    private float speed = 0.5f;      // Tốc độ di chuyển
    private float startY;          // Vị trí Y ban đầu
    public GameObject button;
    private bool isMovingDown = false;
    private bool isMovingUp = false;

    private void Start()
    {
        startY = button.transform.position.y; // Lưu vị trí Y ban đầu
        
    }

    private void Update()
    {
        moving(); // Gọi liên tục trong Update để xử lý di chuyển
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("main"))
        {
            isMovingDown = true;
            isMovingUp = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("main"))
        {
            isMovingUp = true;
            isMovingDown = false;
        }
    }


    private void moving()
    {
        if (isMovingDown)
        {
            button.transform.position += Vector3.down * speed * Time.deltaTime;

            if (button.transform.position.y <= startY - 0.5f)
            {
                button.transform.position = new Vector3(button.transform.position.x, startY - 0.5f, button.transform.position.z);
                isMovingDown = false;
            }
        }
        else if (isMovingUp)
        {
            button.transform.position += Vector3.up * speed * Time.deltaTime;

            if (button.transform.position.y >= startY)
            {
                button.transform.position = new Vector3(button.transform.position.x, startY, button.transform.position.z);
                isMovingUp = false;
            }
        }
    }
}
