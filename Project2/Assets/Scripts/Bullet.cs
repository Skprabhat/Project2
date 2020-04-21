using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool moveLeft;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (moveLeft)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            //have to Flip Bullet...........................
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
