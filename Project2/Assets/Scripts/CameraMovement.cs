using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Vector3 camerPos;
    public Transform player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 PlayerScreenPos = Camera.main.WorldToViewportPoint(player.position);
            //checking whether player is inside the cam or not
            if (PlayerScreenPos.z > 0 && (PlayerScreenPos.x > 0 && PlayerScreenPos.x < 1) && (PlayerScreenPos.y > 0 && PlayerScreenPos.y < 1))
            {
                Debug.Log("Inside cam");
            }
            else
            {
                Debug.Log("Outside cam");
            }
        }
        //moving camera on x-axis
        camerPos = this.transform.position;
        camerPos.x += speed;
        camerPos.z = -10;
        this.transform.position = camerPos;
    }
}
