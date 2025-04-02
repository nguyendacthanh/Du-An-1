using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveSpeed = 50f; 
    private float jumpForce = 100f; 
    public float gravityScale = 1f; 
    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded;
    private bool facingRight = true; 
    private bool isDead = false; 
    public GameObject panelLost;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb.gravityScale = gravityScale;
    }

    void Update()
    {
        if (!isDead) 
        {
            MovePlayer();
            Jump();
            UpdateAnimation();
        }
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
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
            anim.SetBool("IsJumping", true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("IsJumping", false);
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
        if (other.gameObject.CompareTag("spike") && !isDead)
        {
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        isDead = true; 
        rb.linearVelocity = Vector2.zero; 
        rb.bodyType = RigidbodyType2D.Static; 
        anim.SetTrigger("IsDie"); 

        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length); // Chờ animation hoàn thành

        panelLost.SetActive(true); 
    }
}


