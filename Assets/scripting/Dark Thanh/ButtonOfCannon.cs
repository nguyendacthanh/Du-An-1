using System;
using UnityEngine;

public class ButtonOfCannon : MonoBehaviour
{
    // demo 
    public float speed = 0.5f;      // Tốc độ di chuyển
    private float startY;          // Vị trí Y ban đầu
    public GameObject button;
    private bool isMovingDown = false,isMovingUp = false;
    public GameObject Cannon;
    

//fsfsfd
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
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("main"))
        {
            isMovingUp = true;
            
        }
    }


    private void moving()
    {
        if (isMovingDown)
        {
            button.transform.position += Vector3.down * speed * Time.deltaTime;

            if (button.transform.position.y <= startY - 1.3f)
            {
                button.transform.position = new Vector3(button.transform.position.x, startY - 1.3f, button.transform.position.z);
                isMovingDown = false;
                Cannon.GetComponent<cannon>().Fire(); 

            }
        }
        if (isMovingUp)
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
