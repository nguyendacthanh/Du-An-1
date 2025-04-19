using System.Collections;
using UnityEngine;

public class spikeHeadTrap : MonoBehaviour
{
    public float speed = 5f;
    public float timeDelay = 1f;  // Thời gian dừng lại trước khi đổi hướng
    private int direction = 1;    // 1 = lên, -1 = xuống
    private Animator animator, anim;
    private bool isWaiting = false;
    public GameObject player, panelLost;

    private void Start()
    {
        animator = GetComponent<Animator>();
        anim =player.GetComponent<Animator>();
    }

    void Update()
    {
        if (!isWaiting)
        {
            // Di chuyển theo trục Y (lên hoặc xuống)
            transform.Translate(Vector2.up * direction * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") && !isWaiting)
        {
            StartCoroutine(WaitAndFlipDirection());
        }

        if (other.gameObject.CompareTag("main"))
        {
            StartCoroutine(ShowLostPanel());
            Destroy(other.gameObject);
        }
    }

    private IEnumerator WaitAndFlipDirection()
    {
        isWaiting = true;

        // Gửi trigger animation tuỳ hướng (tuỳ chỉnh theo animator của bạn)
        if (direction == 1)
            animator.SetTrigger("HitUp");
        else
            animator.SetTrigger("HitDown");

        // Dừng lại trong khoảng thời gian đã định
        yield return new WaitForSeconds(timeDelay);

        // Đổi hướng sau khi chờ
        direction *= -1;

        isWaiting = false;
    }
    private IEnumerator ShowLostPanel()
    { 
        anim.SetTrigger("IsDie");
        yield return new WaitForSeconds(1.5f); 
        Destroy(player);
        panelLost.SetActive(true); 
    }
}