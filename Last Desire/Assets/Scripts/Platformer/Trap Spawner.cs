using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public float timeBetweenSpawns;
    float nextSpawnTime;
    public GameObject trap;
    public AudioClip spawnSound;
    SFX sfx;

    private void Start()
    {
        sfx = FindObjectOfType<SFX>();
    }

    private void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + timeBetweenSpawns;
            foreach (Transform t in spawnPoints)
            {
                sfx.PlayAnyAudio(spawnSound);
                Instantiate(trap,t.position,Quaternion.identity);
            }

        }
        
    }

}
