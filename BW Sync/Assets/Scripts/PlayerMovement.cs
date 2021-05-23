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
    public GameObject pivot;
    Rigidbody2D rb;
    float flip = 0f;
    int c;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        body = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //horizontal = Input.GetAxisRaw("Horizontal");

        if (isGrounded && (Input.GetKeyDown(KeyCode.Space)))
        {
            body.AddForce(pivot.transform.up * jumpPower/2, ForceMode2D.Impulse);
        }
        if(!isGrounded)
        {
            transform.Translate(pivot.transform.up * jumpPower * Time.deltaTime);

        }

    }
    /*void FixedUpdate()
    {
        if (isGrounded)
        {
            //rb.constraints = RigidbodyConstraints2D.None;

            body.AddForce(transform.right * moveSpeed);
        }
        //sprite.flipX = horizontal > 0 ? false : (horizontal < 0 ? true : sprite.flipX);
       
           // rb.constraints = RigidbodyConstraints2D.FreezeRotation;
      


    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Planet 1")
        {
            ContactPoint2D contact = collision.contacts[0];
            Vector2 pos = contact.point;
            transform.position = pos;
            transform.rotation = transform.rotation;
            pivot.transform.eulerAngles = Vector3.forward * flip ;
            

            flip += 180f;
          
            gameObject.transform.SetParent(collision.collider.gameObject.transform);
          
            isGrounded = true;
        }
        
    }

   

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Planet 1")
        {
            isGrounded = false;
            gameObject.transform.parent = null;
           // rb.isKinematic = true;

        }


    }
    /*private void OnCollisionExit2D(Collision2D collision)
    {

        {
            isGrounded = false;
        }
        
    }
    // Update is called once per frame
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
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
                Debug.Log(distance);

            }

           
        }
    }

    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.CompareTag("Planet 1"))
        {
            body.drag = 0.2f;
        }
    }*/

}
