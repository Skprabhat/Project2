using System.Collections;
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
        if (collision.gameObject.tag == "barrier")
        {
            instance.pause = true;
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
        }
    }
}
