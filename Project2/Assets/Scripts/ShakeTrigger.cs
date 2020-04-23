using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeTrigger : MonoBehaviour
{
    public CameraMovement instance;
    public CameraShake CS;

    void Start()
    {
        instance = GameObject.Find("CamShake").GetComponent<CameraMovement>();

    }

    
    void Update()
    {
        if(instance.pause == true)
        {
            StartCoroutine(CS.Shake(.15f, .2f));
        }
    }
}
