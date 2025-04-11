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
    private bool isDead = false;
    public KeyCode moveLeftKey = KeyCode.A;
    public KeyCode moveRightKey = KeyCode.D;
    public KeyCode jumpKey = KeyCode.W;

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
        float moveX = 0f;

        if (Input.GetKey(moveLeftKey ))
        {
            moveX = -1;
            if (facingRight) Flip();
        }
        if (Input.GetKey(moveRightKey))
        {
            moveX = 1;
            if (!facingRight) Flip();
        }

        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);
    }

    void Jump()
    {
        if (isDead) return;
        if (Input.GetKeyDown(jumpKey) && canJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // sửa lại: linearVelocity → velocity
            canJump = false; // Chỉ nhảy khi đang trên đất
            anim.SetBool("IsJumping", true);
            // KHÔNG cần coroutine nữa
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("spike"))
        {
            
           
            StartCoroutine(ShowLostPanel());
        }
    }
    private IEnumerator ShowLostPanel()
    { 
        isDead = true;
        anim.SetTrigger("IsDie");
        yield return new WaitForSeconds(1.5f); 
        Destroy(gameObject);
        panelLost.SetActive(true); 
    }
}
