using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dumbster : MonoBehaviour
{
   

    // PlayerMovement unused script for future ref if needed
    //void Update()
    //{
        /*horizontal = Input.GetAxisRaw("Horizontal");

   // if(pivot.transform.rotation != Quaternion.Euler(0, 0, 0))
   // {
   //     pivot.transform.rotation = Quaternion.Euler(0, 0, 0);
   // }
    if (isGrounded && (Input.GetKeyDown(KeyCode.Space)))
    {


        //transform.Translate(transform.up * jumpPower * Time.deltaTime);

        if (move)
        {
                body.AddForce(pivot.transform.up * jumpPower / 2, ForceMode2D.Impulse);
            //transform.rotation = Quaternion.Euler(0, 0, 0);

           // transform.Translate(pivot.transform.up * jumpPower * Time.deltaTime);

        }
        else
        {
              body.AddForce(-pivot.transform.up * jumpPower / 2, ForceMode2D.Impulse);
            //transform.rotation = Quaternion.Euler(0, 0, 0);

            //transform.Translate(-pivot.transform.up * jumpPower * Time.deltaTime);

        }
    }
    if(!isGrounded)
    {
        Debug.Log("!isgrounded");
        //transform.Translate(transform.up * jumpPower * Time.deltaTime);

         if (move)
         {
             transform.Translate(pivot.transform.up * jumpPower * Time.deltaTime);


         }
         else
         {
             transform.Translate(-pivot.transform.up * jumpPower * Time.deltaTime);

         }
    }*/
   // }
    //private void FixedUpdate()
    //{
       /* if (isGrounded)
        {
            //rb.constraints = RigidbodyConstraints2D.None;

            body.AddForce(transform.right * moveSpeed);
        }
        //sprite.flipX = horizontal > 0 ? false : (horizontal < 0 ? true : sprite.flipX);

        // rb.constraints = RigidbodyConstraints2D.FreezeRotation;*/
   // }

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
