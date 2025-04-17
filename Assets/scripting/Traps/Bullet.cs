using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;


    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        
    }
    

    private void OnCollisionEnter2D(Collision2D other)
    {
         if (other.gameObject.CompareTag("walldoor"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

        }
        else if (other.gameObject.CompareTag("main"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
