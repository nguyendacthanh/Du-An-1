using UnityEngine;

public class walldoor : MonoBehaviour
{
    public GameObject door; // Kéo thả cửa vào đây trong Inspector
    public float speed = 2f; // Vận tốc di chuyển xuống
    private bool isMoving = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Main")) // Kiểm tra va chạm với tag "Main"
        {
            isMoving = true;
        }
    }

    void Update()
    {
        if (isMoving)
        {
            door.transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }
}
