using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
     float degree = 50f;
    public float speed = 1f; 
    int a;
    // Start is called before the first frame update
    void Start()
    {
        a = Random.Range(0, 2);
        Debug.Log(gameObject.name + a);
    }

    // Update is called once per frame
    void Update()
    {
        if(a == 0 )
        {
            degree += speed;
            transform.eulerAngles = Vector3.forward * degree;

        }
       else
        {
            degree -= speed;
            transform.eulerAngles = Vector3.forward * degree;

        }
        

    }
}
