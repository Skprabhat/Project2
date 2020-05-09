using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour
{
    [Header("Stats")]
    [Space]
    public float speed;



    [Space]
    public float jumpForce;
    public float jumptime;
    public float checkRadius;
    private float jumpTimeCounter;
    private float inputX;



    //public GameObject panel;

    public Transform groundCheck;
    public LayerMask whatIsGround;
    private Rigidbody2D rb;
    public GameObject player2;
    public GameObject Pausepanel;
    public GameObject GameoverPanel;
   

    private bool isGrounded;
    private bool isJumping;
    bool isPause;
    private bool canJump = true;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
      
        Time.timeScale = 1;
        
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
        else
        {
            Pausepanel.SetActive(false);
            //Time.timeScale = 1;
        }
        if (gameObject.transform.position.y < -39.0f)
        {
            Debug.Log("dead");
            gameObject.SetActive(false);
        }


        //checking whether player is Grounded or not
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        //getting x-axis Input

        inputX = Input.GetAxisRaw("Horizontal");

        //calling Jump Function

        Jump();

        //EndGame();


    }
    private void FixedUpdate()
    {



        rb.velocity = new Vector2(inputX * speed, rb.velocity.y);




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
        if (collision.gameObject.tag == "WaterBarrier") 
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "EndGame")
        {
            gameObject.SetActive(false);
            player2.SetActive(true);
            SceneManager.LoadScene("MainScene 1");
        }
        if (collision.gameObject.tag == "EndGame3")
        {
            gameObject.SetActive(false);

            SceneManager.LoadScene("Level4load");
        }
        if (collision.gameObject.tag == "Spikes")
        {
            GameoverPanel.SetActive(true);
        }
        if (collision.gameObject.tag == "WaterBarrier")
        {
            GameoverPanel.SetActive(true);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            GameoverPanel.SetActive(true);
        }
    }

}
