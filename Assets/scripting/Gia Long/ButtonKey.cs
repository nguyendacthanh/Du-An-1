using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class ButtonKey : MonoBehaviour
{
    private float speed = 0.5f;     
    private float startY;          
    public GameObject button;
    private bool isMovingDown = false;
    public GameObject doorWall;
    
    
    private void Start()
    {
        startY = button.transform.position.y; 
        
        
    }

    private void Update()
    {
        moving(); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("main"))
        {
            isMovingDown = true;
            
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
                Destroy(doorWall);
            }
        }
    }
}
