using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 moveDirection;
    public float speed;
    public float jumpSpeed;
    Rigidbody2D rb;
    public Transform myFeet;

    bool canJump;
    bool isGrounded;
    bool isJumping = false;

    public LayerMask groundLayer;
    public float jumpRadius;

    Animator anim;
    private bool isFacingRight = true;

    AudioSource myAudio;
    SFX sfx;
    public AudioClip jumpSound;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        myAudio = GetComponent<AudioSource>();
        sfx = FindObjectOfType<SFX>();
    }

    private void FixedUpdate()
    {
        Walk();
        if(isGrounded && canJump && !isJumping)
        {
            sfx.PlayAnyAudio(jumpSound);
            anim.SetTrigger("jump");
            rb.velocity = Vector2.up * jumpSpeed;
            canJump = false;
            isJumping = true;
        }
    }

    void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
    }

    void Walk()
    {
        Vector2 playerVelocity = new Vector2(moveDirection.x * speed * Time.fixedDeltaTime,0);
        rb.velocity = playerVelocity;
        if(Mathf.Abs(moveDirection.x)>0)
        {
            anim.SetBool("isWalking", true);
            myAudio.enabled = true;
        }
        else
        {
            anim.SetBool("isWalking", false);
            myAudio.enabled = false;
        }
    }

    void OnJump(InputValue value)
    {
        if(value.isPressed && !isJumping)
        {
            canJump = true;
        }
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(myFeet.position,jumpRadius,groundLayer);

        if(isGrounded && isJumping)
        {
            isJumping = false;
        }

        FlipSprite();
    }

    void FlipSprite()
    {
        if (moveDirection.x < 0 && isFacingRight)
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
            isFacingRight = false;
        }
        else if (moveDirection.x > 0 && !isFacingRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            isFacingRight = true;
        }
    }

}
