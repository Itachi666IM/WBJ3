using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racquet2 : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    [HideInInspector] public Vector2 defaultPos;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultPos = transform.position;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = speed * Vector2.up;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.velocity = speed * Vector2.down;
        }
    }

    public void ResetVelocity()
    {
        rb.velocity = Vector2.zero;
    }
}
