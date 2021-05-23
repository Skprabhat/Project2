using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    public float moveSpeed=10f, jumpPower=10f;
    public SpriteRenderer sprite;

    Rigidbody2D body;
    public bool isGrounded = false;
    float horizontal;
   
    
    // Start is called before the first frame update
    void Start()
    {
       
        body = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
           isGrounded = true;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        {
            isGrounded = false;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (isGrounded && (Input.GetKeyDown(KeyCode.Space)))
        {
            body.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }

    void FixedUpdate()
    {
        //if (isGrounded)
        //{
        
            body.AddForce(transform.right * horizontal * moveSpeed);
        //}
        //sprite.flipX = horizontal > 0 ? false : (horizontal < 0 ? true : sprite.flipX);
    }
    

    void OnTriggerStay2D(Collider2D obj)
    {
        if (obj.CompareTag("Planet 1"))
        {
            body.drag = 1f;

            float distance = Mathf.Abs(obj.GetComponent<GravityPoint>().planetRadius - Vector2.Distance(transform.position, obj.transform.position));
            if (distance < 1f)
            {
                isGrounded = distance < 0.93f;
               // Debug.Log(distance);

            }
        }
    }

    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.CompareTag("Planet 1"))
        {
            body.drag = 0.2f;
        }
    }
   
}
