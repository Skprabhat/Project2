using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    public float moveSpeed=10f, jumpPower=10f;
    public SpriteRenderer sprite;

    Rigidbody2D body;
    CircleCollider2D cc;
    SpriteRenderer sr;

    string circleName;

    public bool isGrounded = false;
    float horizontal;
    //public GameObject pivot;
    Vector3 upDir;
    Rigidbody2D rb;
    float flip = 0f;
    int c;
    bool move = false;
    Spawner spawn;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        //spawn = GameObject.Find("SpawnPoints").GetComponent<Spawner>();
    }
   
  
    void Update()
    {
        if (isGrounded && (Input.GetKeyDown(KeyCode.Space)))
        {
            body.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);

            if (move)
            {
                body.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);

            }
            else if (move)
            {
                body.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);

            }
        }
      
      


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Planet 1")
        {
            ContactPoint2D contact = collision.contacts[0];
            Vector2 pos = contact.point;
            transform.position = pos;

            SetPlayerUp(gameObject.transform, collision.gameObject.transform);   

            gameObject.transform.SetParent(collision.collider.gameObject.transform);
          
            isGrounded = true;
        }

       
       
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            collision.gameObject.SetActive(false);
            //spawn.Spawn();
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Planet 1")
        {
            isGrounded = false;
            gameObject.transform.parent = null;

        }


    }
    static void SetPlayerUp(Transform player, Transform planet)
    {
        player.rotation = Quaternion.LookRotation(Vector3.forward,
                player.position - planet.position);
    }

   

}
