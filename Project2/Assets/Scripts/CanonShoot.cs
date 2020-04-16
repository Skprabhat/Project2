using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonShoot : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    public GameObject panel;
    public Transform spawnPoint;

    public float timer = 2f;
    private float timeLeft;

    void Start()
    {
         timeLeft = timer;
    }

    void Update()
    {
        //timeLeft--;
       if(timeLeft <= 0)
        {
            Shoot();
            timeLeft = timer;
        }
        else
        {
            timeLeft -= Time.deltaTime;
           // timeLeft = timer;
        }
        
    }

    void Shoot()
    {
        if (player.activeInHierarchy && Vector2.Distance(player.transform.position, gameObject.transform.position) < 10f && !panel.activeInHierarchy)
        {
            Debug.Log("pew pew");
            Instantiate(bullet, spawnPoint.position, Quaternion.identity);
             
        }
    }
}
