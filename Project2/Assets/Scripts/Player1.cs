using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //public GameObject panel;

    public Transform groundCheck;
    public LayerMask whatIsGround;
    private Rigidbody2D rb;

    private bool isGrounded;
    private bool isJumping;

    void Start()
    {
        Time.timeScale = 1;
        rb = this.GetComponent<Rigidbody2D>();
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
        EndGame();
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
    void EndGame()
    {
        FindObjectOfType<ScoreManager>().GameOver();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Spikes"))
        {
            EndGame();
        }
    }
}
