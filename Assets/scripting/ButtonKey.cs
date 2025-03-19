using System;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class ButtonKey : MonoBehaviour
{
    private float speed = 0.5f;
    private float startY;
    private bool isMovingDown = false;
    private bool isMovingUp = false;

    private void Start()
    {
        startY = transform.position.y;
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("main"))
        {
            isMovingDown = true;
            moving();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("main") && transform.position.y < startY)
        {
            isMovingUp = true;
            moving();
        }
    }

    public void moving()
    {
        if (isMovingDown)
        {
            transform.position += Vector3.down*speed*Time.deltaTime;
            if (transform.position.y <= startY-0.5f)
            {
                transform.position = new Vector3(transform.position.x, startY-0.5f, transform.position.z);
                isMovingDown = false;
            }
        }
        else if (isMovingUp)
        {
            transform.position += Vector3.up*speed*Time.deltaTime;

            if (transform.position.y == startY)
            {
                transform.position = new Vector3(transform.position.x, startY, transform.position.z);
                isMovingUp = false;
            }
        }
        
    }
}
