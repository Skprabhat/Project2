﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public float speed;

    void Update()
    {
        //moving gameobj downwards
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Ground"))
        //{
        //    //Should Add Particle Effect Particle Effect
        //    Destroy(gameObject);
        //}
    }
}