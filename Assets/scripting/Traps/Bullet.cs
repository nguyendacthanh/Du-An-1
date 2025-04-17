using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("main"))
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("walldoor"))
        {
            Destroy(other.gameObject);
        }
    }
}
