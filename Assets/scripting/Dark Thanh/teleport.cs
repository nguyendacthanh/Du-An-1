using UnityEngine;

public class teleport : MonoBehaviour
{
    public GameObject main; // GameObject A sẽ được teleport
    public float x,y;    // Vị trí (x, y) cần dịch chuyển đến

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("main"))
        {
            Vector3 currentPos = main.transform.position;
            main.transform.position = new Vector3(
                x,
                y,
                currentPos.z // giữ nguyên Z
            );
        }
    }
}
