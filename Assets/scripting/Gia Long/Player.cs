using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
public class Player : MonoBehaviour
{
    private float moveSpeed = 50f;
    private float jumpForce = 100f;
    public float gravityScale = 1f;
    private Rigidbody2D rb;
    private Animator anim;
    private bool facingRight = true;
    private bool canJump = true;
    private bool isDead = false;

    public KeyCode moveLeftKey = KeyCode.A;
    public KeyCode moveRightKey = KeyCode.D;
    public KeyCode jumpKey = KeyCode.W;
    
    private float moveInput = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
        if (isDead) return;

        float moveX = moveInput; // moveInput mặc định = 0, chỉ có giá trị nếu có button UI nhấn

        // Bàn phím vẫn hoạt động bình thường
        if (Input.GetKey(moveLeftKey))
        {
            moveX = -1;
        }
        if (Input.GetKey(moveRightKey))
        {
            moveX = 1;
        }

        // Xử lý Flip
        if (moveX < 0 && facingRight) Flip();
        else if (moveX > 0 && !facingRight) Flip();

        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);
    }

    void Jump()
    {
        if (isDead) return;

        if (Input.GetKeyDown(jumpKey) && canJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            canJump = false;
            anim.SetBool("IsJumping", true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (collision.gameObject.CompareTag("Ground") && contact.normal.y > 0.5f)
            {
                canJump = true;
                anim.SetBool("IsJumping", false);
                break;
            }
        }
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
    
    public void JumpFromButton()
    {
        if (isDead || !canJump) return;

        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        canJump = false;
        anim.SetBool("IsJumping", true);
    }

    public void MoveLeftButtonDown()
    {
        moveInput = -1f;
    }

    public void MoveRightButtonDown()
    {
        moveInput = 1f;
    }

    public void MoveButtonUp()
    {
        moveInput = 0f;
    }
}

