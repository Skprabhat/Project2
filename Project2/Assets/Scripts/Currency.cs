using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public float speed;

    private void Awake()
    {
        Invoke("Function", 4f);

    }

    void Update()
    {
        //moving gameobj downwards
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    void Function()
    {
        //destroying gob after 4 sec
        Destroy(gameObject);
    }

}
