using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] Positions;
    public GameObject[] Object;

    private int rand;
    private int randposition;

    public float startTimeBtwSpawns;
    private float timeBtwSpawns;

    private void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
    }
    private void Update()
    {
        if (timeBtwSpawns <= 0)
        {

            rand = Random.Range(0, Object.Length);
            randposition = Random.Range(0, Positions.Length);
            Instantiate(Object[rand], Positions[randposition].transform.position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
    }

