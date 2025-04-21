using System;
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

    public AudioClip runSound;
    public AudioClip jumpSound;

    private AudioSource runAudioSource;
    private AudioSource sfxAudioSource;

    public int requiredJumpPresses = 1;
    private int currentJumpPresses = 0;
    private float jumpPressTimer = 0f;
    public float jumpPressResetTime = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb.gravityScale = gravityScale;

        AudioSource[] sources = GetComponents<AudioSource>();
        runAudioSource = sources[0];
        sfxAudioSource = sources[1];
    }

    void Update()
    {
        Time.timeScale = 1f;
        MovePlayer();
        Jump();
        UpdateAnimation();
    }

    void MovePlayer()
    {
        if (isDead) return;

        float moveX = moveInput;

        if (Input.GetKey(moveLeftKey)) moveX = -1;
        if (Input.GetKey(moveRightKey)) moveX = 1;

        if (moveX < 0 && facingRight) Flip();
        else if (moveX > 0 && !facingRight) Flip();

        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);
    }

    void Jump()
    {
        if (isDead) return;

        if (Input.GetKeyDown(jumpKey))
        {
            currentJumpPresses++;
            jumpPressTimer = jumpPressResetTime;

            if (currentJumpPresses >= requiredJumpPresses && canJump)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                canJump = false;
                anim.SetBool("IsJumping", true);
                sfxAudioSource.PlayOneShot(jumpSound);
                currentJumpPresses = 0; 
            }
        }

        if (jumpPressTimer > 0)
        {
            jumpPressTimer -= Time.deltaTime;
            if (jumpPressTimer <= 0)
            {
                currentJumpPresses = 0;
            }
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
        bool isRunning = Mathf.Abs(rb.linearVelocity.x) > 0.1f;
        bool isJumping = !canJump;

        anim.SetBool("IsRunning", isRunning);
        anim.SetBool("IsJumping", isJumping);

        if (isRunning && !isJumping && !runAudioSource.isPlaying)
        {
            runAudioSource.clip = runSound;
            runAudioSource.loop = true;
            runAudioSource.Play();
        }
        else if (!isRunning || isJumping)
        {
            if (runAudioSource.isPlaying && runAudioSource.clip == runSound)
            {
                runAudioSource.Stop();
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    public void JumpFromButton()
    {
        if (isDead) return;

        currentJumpPresses++;
        jumpPressTimer = jumpPressResetTime;

        if (currentJumpPresses >= requiredJumpPresses && canJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            canJump = false;
            anim.SetBool("IsJumping", true);
            sfxAudioSource.PlayOneShot(jumpSound);
            currentJumpPresses = 0;
        }
    }

    public void MoveLeftButtonDown() => moveInput = -1f;
    public void MoveRightButtonDown() => moveInput = 1f;
    public void MoveButtonUp() => moveInput = 0f;
}


