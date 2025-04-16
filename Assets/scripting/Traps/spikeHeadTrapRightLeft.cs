using System;
using System.Collections;
using UnityEngine;

public class spikeHeadTrapRightLeft : MonoBehaviour
{
    public float speed = 5f;
    private int direction = 1;
    private Animator animator;
    private bool isWaiting = false;
    public float timeDelay = 1f; 

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Chỉ di chuyển nếu không đang dừng
        if (!isWaiting)
        {
            transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
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
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ChanceMove") && !isWaiting)
        {
            StartCoroutine(WaitAndFlipDirection());
        }
        if (other.gameObject.CompareTag("main"))
        {
            Destroy(other.gameObject);
        }
    }

    private IEnumerator WaitAndFlipDirection()
    {
        isWaiting = true;

        // Gửi trigger animation tùy theo hướng hiện tại
        if (direction == 1)
            animator.SetTrigger("HitRight");
        else
            animator.SetTrigger("HitLeft");

        // Dừng lại 1 giây
        yield return new WaitForSeconds(timeDelay);

        // Đổi hướng sau khi đợi
        direction *= -1;

        isWaiting = false;
    }
}