using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : MonoBehaviour
{
    SFX sfx;
    GameManager gameManager;
    [SerializeField] AudioClip pickupSound;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        sfx = FindObjectOfType<SFX>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            sfx.PlayAnyAudio(pickupSound);
            gameManager.IncreaseDynamiteCount();
            Destroy(gameObject);
        }
    }
}
