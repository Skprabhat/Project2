﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPause : MonoBehaviour
{
    public CameraMovement instance;

    private void Start()
    {
        instance = GameObject.Find("CamShake").GetComponent<CameraMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("sii");
        if (collision.gameObject.tag == "barrier")
        {
            Debug.Log("hi");
           instance.pause = true;
            Destroy(collision.gameObject);
        }
    }
}