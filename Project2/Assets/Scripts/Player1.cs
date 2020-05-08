﻿using System.Collections;
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

    public Transform groundCheck;
    public LayerMask whatIsGround;
    private Rigidbody2D rb;

    private bool isGrounded;
    private bool isJumping;
    private bool inWater;
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

        watertimer();

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
            EndGame();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            FindObjectOfType<UIManager>().GameOverMenu.SetActive(true);
            EndGame();
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            inWater = true;
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            FindObjectOfType<UIManager>().GameOverMenu.SetActive(true);
            EndGame();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            inWater = false;
        }
        if (collision.gameObject.tag == "EndGame2")
        {
            //gameObject.SetActive(false);

            SceneManager.LoadScene("Load2");
        }
        if (collision.gameObject.tag == "EndGame1")
        {
          //  gameObject.SetActive(false);

            SceneManager.LoadScene("Load1");
        }
    }
 
}
