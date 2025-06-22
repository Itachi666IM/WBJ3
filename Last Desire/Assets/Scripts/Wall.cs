using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    PongManager pongManager;
    public GameObject ballPrefab;
    
    private void Start()
    {
        pongManager = FindObjectOfType<PongManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ball")
        {
            pongManager.UpdateScore1();
            Destroy(collision.gameObject);
            Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
