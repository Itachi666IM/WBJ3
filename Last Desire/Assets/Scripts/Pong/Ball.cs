using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    int moveDirection = 1;
    Rigidbody2D rb;
    public ParticleSystem hitEffect;
    SFX sfx;
    public AudioClip hitSound;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * speed * moveDirection;
        sfx = FindObjectOfType<SFX>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        sfx.PlayAnyAudio(hitSound);
        hitEffect.Play();
    }

}
