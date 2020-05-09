using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour
{
    [Header("Stats")]
    [Space]
    public float speed;
    public float _speed = 10f;


    [Space]
    public float jumpForce;
    public float jumptime;
    public float checkRadius;
    private float jumpTimeCounter;
    private float inputX;
   // private float inputY;
    public float pushF;
    public float pullF;
    public float rpullF;
    //public float gravityScale;


    //public GameObject panel;

    public Transform groundCheck;
    public LayerMask whatIsGround;
    private Rigidbody2D rb;
    public CameraShake CS;
    public GameObject Pausepanel;
    public GameObject GameoverPanel;


    private bool isGrounded;
    private bool isJumping;
    bool isPause;
    private bool canJump = true;
    private bool underWater = false;
    private bool pullZone = false;
    private bool pullZoner = false;
    private bool pushZone = false;
    private bool dPush = false;





    void Start()
    {
        Time.timeScale = 1;
        rb = this.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
        }
        if (isPause)
        {
            Pausepanel.SetActive(true);
            //Time.timeScale = 0;
        }
        if(!isPause)
        {
            Pausepanel.SetActive(false);
        }

        if (gameObject.transform.position.y < -4f)
        {
            // Debug.Log("under");
            underWater = true;
        }
        if (underWater == false)
        {


            //checking whether player is Grounded or not
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
            //getting x-axis Input

            inputX = Input.GetAxisRaw("Horizontal");

            //calling Jump Function

            Jump();

            //EndGame();
        }
        if (underWater == true)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.Translate(Vector3.up * _speed * Time.deltaTime);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                transform.Translate(Vector3.down * _speed * Time.deltaTime);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                //Debug.Log("left");
                transform.Translate(Vector3.left * _speed * Time.deltaTime);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.Translate(Vector3.right * _speed * Time.deltaTime);
            }

        }
        if(gameObject.transform.position.y < -38f)
        {
            StartCoroutine(CS.Shake(.15f, .2f));

        }
    }
    private void FixedUpdate()
    {


        if (underWater == true)
        {
            rb.velocity = new Vector2(0f, 0.2f);
            //rb.gravityScale = 
        }

        else
        {
            rb.velocity = new Vector2(inputX * speed, rb.velocity.y);

        }

        if (pullZone == true)
        {
            rb.velocity = new Vector2(pullF, 0f);

        }
        if (pullZoner == true)
        {
            rb.velocity = new Vector2(rpullF, 0f);

        }
        if (pushZone == true)
        {
            rb.velocity = new Vector2(0f, pushF);

        }
        if (dPush == true)
        {
            //Vector2 force = new Vector2(0f, -100f);
            //rb.AddForce(force);
            rb.velocity = new Vector2(0f, -150f);
        }

    }
    private void Jump()
    {
        //if player is Grounded then Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
            jumpTimeCounter = jumptime;
            // FindObjectOfType<AudioManager>().play("Jump");
            rb.velocity = Vector2.up * jumpForce;
        }
        //setting isjump to false
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
        //if isjump is true then adding extra jump force
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
    }
    void EndGame()
    {
        FindObjectOfType<ScoreManager>().GameOver();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Spikes"))
        //{
        //    EndGame();
        //}
       

        if (collision.gameObject.CompareTag("pull"))
        {
            pullZone = true;
        }
        if (collision.gameObject.CompareTag("pullr"))
        {
            pullZoner = true;
        }

        if (collision.gameObject.CompareTag("push"))
        {
            pushZone = true;
        }
        if (collision.gameObject.CompareTag("Dpush"))
        {
            dPush = true;
        }
        if (collision.gameObject.tag == "Spikes")
        {
            GameoverPanel.SetActive(true);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            GameoverPanel.SetActive(true);
        }
        if (collision.gameObject.tag == "EndGame")
        {


            SceneManager.LoadScene("Level4load");

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pull"))
        {
            pullZone = false;
        }

        if (collision.gameObject.CompareTag("pullr"))
        {
            pullZoner = false;
        }

        if (collision.gameObject.CompareTag("push"))
        {
            pushZone = false;
        }
        if (collision.gameObject.CompareTag("Dpush"))
        {
            dPush = false;
        }
      

    }

}
