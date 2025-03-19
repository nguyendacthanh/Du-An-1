using UnityEngine;

public class onTriggerDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ccc
        ////
        if (collision.gameObject.CompareTag("main"))
        {
            Destroy(collision.gameObject);
        }
    }
}
