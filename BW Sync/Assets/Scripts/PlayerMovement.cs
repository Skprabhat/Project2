using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
   
    public float moveSpeed=10f, jumpPower=10f;
    public SpriteRenderer sprite;
    public GameObject GameOver;
    public GameObject Score;

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
        if (collision.gameObject.tag == "Coins")
        {
            ScoreManager.instance.AddPoint();
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Wall")
        {
            //GameObject.SetActive(true);
            Debug.Log("hit");
            GameOver.SetActive(true);
            Score.SetActive(false);
        }
        if (collision.gameObject.tag == "Walls")
        {
            //GameObject.SetActive(true);
            Debug.Log("hit");
            GameOver.SetActive(true);
            //Score.SetActive(false);
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
