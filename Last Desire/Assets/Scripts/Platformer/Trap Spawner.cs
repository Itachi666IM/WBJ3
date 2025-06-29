using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public float timeBetweenSpawns;
    float nextSpawnTime;
    public GameObject trap;


    private void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + timeBetweenSpawns;
            foreach (Transform t in spawnPoints)
            {
                Instantiate(trap,t.position,Quaternion.identity);
            }

        }
        
    }

}
