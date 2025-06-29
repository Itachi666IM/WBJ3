using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap : MonoBehaviour
{
    public float speed;
    public Transform destination;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,3f);
    }

    // Update is called once per frame
    void Update()
    {
        Invoke(nameof(DelayedFall), 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SceneManager.LoadScene("Platformer Fail");
        }
    }

    void DelayedFall()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);
    }
}
