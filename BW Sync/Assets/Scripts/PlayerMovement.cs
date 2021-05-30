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
    public GameObject pivot;
    Vector3 upDir;
    Rigidbody2D rb;
    float flip = 0f;
    int c;
    bool move = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        body = GetComponent<Rigidbody2D>();
         cc = GetComponent<CircleCollider2D>();
         sr = GetComponent<SpriteRenderer>();

    }
    void Update()
    {
        //horizontal = Input.GetAxisRaw("Horizontal");

       // if(pivot.transform.rotation != Quaternion.Euler(0, 0, 0))
       // {
       //     pivot.transform.rotation = Quaternion.Euler(0, 0, 0);
       // }
        if (isGrounded && (Input.GetKeyDown(KeyCode.Space)))
        {
                

            //transform.Translate(transform.up * jumpPower * Time.deltaTime);

            if (move)
            {
                //body.AddForce(pivot.transform.up * jumpPower / 2, ForceMode2D.Impulse);
                //transform.rotation = Quaternion.Euler(0, 0, 0);

                transform.Translate(pivot.transform.up * jumpPower * Time.deltaTime);

            }
            else
            {
                //  body.AddForce(-pivot.transform.up * jumpPower / 2, ForceMode2D.Impulse);
                //transform.rotation = Quaternion.Euler(0, 0, 0);

                transform.Translate(-pivot.transform.up * jumpPower * Time.deltaTime);

            }
        }
        if(!isGrounded)
        {

            //transform.Translate(transform.up * jumpPower * Time.deltaTime);

             if (move)
             {
                 transform.Translate(pivot.transform.up * jumpPower * Time.deltaTime);


             }
             else
             {
                 transform.Translate(-pivot.transform.up * jumpPower * Time.deltaTime);

             }
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
            //collision.gameObject.transform.up = upDir;
           // transform.rotation = transform.rotation;
            // circleName = collision.gameObject.name ;
            Invoke("Flip", 0.1f);
          
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

    void Flip()
    {
        Debug.Log("Inside flip");
        //pivot.transform.eulerAngles.z = 0;
        // pivot.transform.rotation = Quaternion.Euler(0, 0, 0);
        //pivot.transform.eulerAngles = Vector3.forward * flip;
        move = !move;
        //flip += 180f;
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
