using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] Positions;
    public GameObject Object;

    private int rand;
    private int randposition;
    //public int coinSpawnCount = 2;

    public float startTimeBtwSpawns;
    private float timeBtwSpawns;

    private void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
        Spawn();

    }
    private void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            Spawn();
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }

    public void Spawn()
    {
        
            randposition = Random.Range(0, Positions.Length);
            Instantiate(Object, Positions[randposition].transform.position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;



    }
}

