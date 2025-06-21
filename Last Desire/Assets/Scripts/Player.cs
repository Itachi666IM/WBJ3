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
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Walk();
        if(isGrounded && canJump && !isJumping)
        {
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
            Debug.Log("Walking...");
            //walk anim
            //walk sfx
        }
        else
        {
            Debug.Log("Standing...");
            //idle anim
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
    }

}
