using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    float timer;
    public float minSpawnTime, maxSpawnTime;
    public bool isReloaded;
    public Transform bullet;
    public bool isLeft;
    public Transform spwanPoint;

    private void Start()
    {
        timer = Random.Range(minSpawnTime, maxSpawnTime);
    }
    // Update is called once per frame
    void Update()
    {
        if (isReloaded)
        {
            Transform obj = Instantiate(bullet, spwanPoint.position, Quaternion.identity) as Transform;
            if (isLeft)
            {
                bullet.GetComponent<SpriteRenderer>().flipX = true;
                obj.GetComponent<Bullet>().moveLeft = true;
            }
            isReloaded = false;
        }
        else
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                timer = Random.Range(minSpawnTime, maxSpawnTime);
                isReloaded = true;
            }
        }
    }
}
