using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool moveLeft;
    public float speed;
    public SpriteRenderer sr;

    void Update()
    {
        if (moveLeft)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            //flipping Bullet for Right Cannon
            sr.flipX = false;
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
           // Debug.Log("gg");
            Destroy(gameObject);
        }
    }
}
