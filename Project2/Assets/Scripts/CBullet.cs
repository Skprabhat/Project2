using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBullet : MonoBehaviour
{
    public float speed = 5f;
    private void Awake()
    {
        Invoke("Function", 3f);
    }


    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void Function()

    {
        Destroy(gameObject);
    }
}
