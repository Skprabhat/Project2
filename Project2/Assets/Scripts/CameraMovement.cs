using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Vector3 camerPos;

    public Transform player;
    public GameObject currency;

    public float speed;
    private bool pause = false;
    public float timer = 10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 PlayerScreenPos = Camera.main.WorldToViewportPoint(player.position);
            //checking whether player is inside the cam or not
            if (PlayerScreenPos.z > 0 && (PlayerScreenPos.x > 0 && PlayerScreenPos.x < 1) && (PlayerScreenPos.y > 0 && PlayerScreenPos.y < 1))
            {
               // Debug.Log("1");
            }
            else
            {
                //Debug.Log("0");
            }
        }
        //PauseCheck();
        MoveCam();
       
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                           Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 100f);
            if (hit.collider != null && hit.collider.tag != "currency")
            {
                Debug.Log("u cant click on that");
            }
            else
            {
                Destroy(hit.collider.gameObject);

            }



        }
        if(pause == true)
        {
            if(timer> 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                MoveCam();
                pause = false;
            }
        }
        }
    
    void PauseCheck()
    {
        if(camerPos.x == 45.0f && camerPos.y == 1.0f && camerPos.z == -10.0f )
        {
            Debug.Log("hi");
            pause = true;
            //Invoke("MoveCam", 10f);
        }
        else
        {
          
            MoveCam();
        }
    }
    void MoveCam()
    {
        camerPos = this.transform.position;
        camerPos.x += speed;
        camerPos.z = -10;
        this.transform.position = camerPos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
         Debug.Log("sii");
        if (collision.gameObject.tag == "barrier")
        {
            Debug.Log("hi");
            pause = true;
            Destroy(collision.gameObject);
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("hi");

    //    if (collision.gameObject.tag == "barrier")
    //    {
    //        Debug.Log("hi");
    //        pause = true;
    //        Destroy(collision.gameObject);
    //    }
    //}
}
