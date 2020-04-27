using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform position1;
    public Transform position2;
    public GameObject[] spawnObj;

    public CameraMovement instance;


    Vector3 spawnPos;
    public float spawnTime;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = spawnTime;
        instance = GameObject.Find("CamShake").GetComponent<CameraMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        spawnPos = new Vector3(Random.Range(position1.position.x, position2.position.x), this.position1.position.y, this.position1.position.z);
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            GameObject spawnObj1 = spawnObj[Random.Range(0, spawnObj.Length)];
            //Spawing currency
            if (instance.pause == true)
            {
                Instantiate(spawnObj1, spawnPos, Quaternion.identity);
                //Destroy(spawnObj1, 4f);
            }

            timer = spawnTime;
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
