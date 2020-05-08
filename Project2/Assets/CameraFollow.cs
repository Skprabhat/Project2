using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    Vector3 Playerpos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Playerpos = player.position + offset;
        Playerpos.z = -10;
        transform.position = Playerpos;
    }
}
