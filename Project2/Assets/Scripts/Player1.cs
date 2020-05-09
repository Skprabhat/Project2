using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour
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

    public float waterTimer = 6f;
    private float EndTimer = 3f;

    public Transform groundCheck;
    public LayerMask whatIsGround;
    private Rigidbody2D rb;
    private CameraMovement CM;

    private bool isGrounded;
    private bool isJumping;
    private bool inWater;
    private bool lvl1 = false;
    public GameObject panel;
    void Start()
    {
        Time.timeScale = 1;
        rb = this.GetComponent<Rigidbody2D>();
        CM = GameObject.Find("CamShake").GetComponent<CameraMovement>();
    }
    // Update is called once per frame
    void Update()
    {

        //checking whether player is Grounded or not
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        //getting x-axis Input
        inputX = Input.GetAxisRaw("Horizontal");
        //calling Jump Function
        Jump();

        watertimer();

        EndGame();
        if(lvl1)
        {
            if (EndTimer < 0)
            {
                SceneManager.LoadScene("MainScene");
               // panel.SetActive(false);
                lvl1 = false;
              
            }
            else
            {
                EndTimer -= Time.deltaTime;
            }
        }
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
            FindObjectOfType<AudioManager>().play("Jump");
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
    public void EndGame()
    {
        FindObjectOfType<ScoreManager>().GameOver();
    }
    void watertimer()
    {
        if (inWater)
        {
            if (waterTimer > 0)
                waterTimer -= Time.deltaTime;
        }
        if (!inWater)
        {
            if (waterTimer < 6)
                waterTimer += (Time.deltaTime);
        }
        //gameover when watertimer < 0
        if (waterTimer < 0)
        {
            FindObjectOfType<UIManager>().GameOverMenu.SetActive(true);
            Debug.Log("insidw water");
            EndGame();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            FindObjectOfType<UIManager>().GameOverMenu.SetActive(true);
            Debug.Log("spikes");

            EndGame();
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            inWater = true;
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            FindObjectOfType<UIManager>().GameOverMenu.SetActive(true);
            Debug.Log("bullet");

            EndGame();
        }
        if(collision.gameObject.CompareTag("Finish"))
        {
            panel.SetActive(true);

            CM.speed = 0f;
            lvl1 = true;
        }
        //if(collision.gameObject.CompareTag("EndGame"))
        //{
        //    SceneManager.LoadScene("MainScene1");
        //}
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            inWater = false;
        }
        if (collision.gameObject.tag == "EndGame2")
        {
            SceneManager.LoadScene("Load2");
        }
    }
 
}
