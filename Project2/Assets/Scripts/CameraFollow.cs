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
        //if(this.transform.position.y<2.5f)
        //{
        //     transform.position.y = 2.5f;
        //}
        Playerpos = player.position + offset;
        Playerpos.z = -10;
        transform.position = Playerpos;
    }
}
