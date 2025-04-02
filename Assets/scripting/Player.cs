using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveSpeed = 50f; // Tốc độ di chuyển
    private float jumpForce = 100f; // Lực nhảy
    public float gravityScale = 1f; // Mức trọng lực
    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded;
    private bool facingRight = true; // Kiểm tra hướng nhân vật
    public GameObject panelLost;
    private bool canJump = true;
    private float jumpCooldown = 0.8f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); // Lấy Animator
        rb.gravityScale = gravityScale;
    }

    void Update()
    {
        MovePlayer();
        Jump();
        UpdateAnimation();
    }

    void MovePlayer()
    {
        float moveX = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1;
            if (facingRight) Flip();
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = 1;
            if (!facingRight) Flip();
        }

        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); 
            canJump = false; // Ngăn nhảy liên tục
            anim.SetBool("IsJumping", true);
            StartCoroutine(ResetJump()); // Bắt đầu đếm thời gian cho phép nhảy lại
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            // Kiểm tra nếu tiếp đất từ trên xuống (không phải va chạm ngang)
            if (collision.gameObject.CompareTag("Ground") && contact.normal.y > 0.5f)
            {
                canJump = true;
                anim.SetBool("IsJumping", false);
                break;
            }
        }
    }
    
    private IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true;
    }
    void UpdateAnimation()
    {
        anim.SetBool("IsRunning", Mathf.Abs(rb.linearVelocity.x) > 0.1f);
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("spike"))
        {
            
           
            StartCoroutine(ShowLostPanel());
        }
    }
    private IEnumerator ShowLostPanel()
    { 
        anim.SetTrigger("IsDie");
        yield return new WaitForSeconds(1.5f); 
        Destroy(gameObject);
        panelLost.SetActive(true); 
    }
}
