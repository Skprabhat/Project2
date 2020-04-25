using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private bool inWater;
    [HideInInspector]
    public float waterTimer=2;
    // Start is called before the first frame update
    void Start()
    {
        inWater = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer();
    }
    private void timer()
    {
        if (inWater)
        {
            if(waterTimer>0)
            waterTimer -= Time.deltaTime;
        }
        if (!inWater)
        {
            if(waterTimer<2)
            waterTimer += (Time.deltaTime) ;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inWater = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inWater = false;
        }
    }
}
