using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Vector3 camerPos;

    public Transform player;
    public GameObject hitCheck;


    public float speed;
    public bool pause = false;
    public float timer = 10f;

    void Update()
    {
        if (player != null)
        {
            Vector3 PlayerScreenPos = Camera.main.WorldToViewportPoint(player.position);
            //checking whether player is inside the cam or not
            if (PlayerScreenPos.z > 0 && (PlayerScreenPos.x > 0 && PlayerScreenPos.x < 1) && (PlayerScreenPos.y > 0 && PlayerScreenPos.y < 1))
            {
                //Do Nothing
            }
            else
            {
                //GameOver
                Debug.Log("outside cam");
                FindObjectOfType<UIManager>().GameOverMenu.SetActive(true);
                FindObjectOfType<Player1>().EndGame();
            }
        }

        MoveCam();

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                           Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 100f);
            if (hit.collider != null && hit.collider.tag == "currency")
            {
                Destroy(hit.collider.gameObject);

            }
        }
        if (pause == true)
        {
            speed = 0f;
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                speed = 0.01f;
                MoveCam();
                pause = false;
                Invoke("Function", 2f);
            }
        }
    }


    void MoveCam()
    {
        camerPos = this.transform.position;
        camerPos.x += speed;
        camerPos.z = -10;
        this.transform.position = camerPos;
    }
    void Function()
    {
        hitCheck.SetActive(true);
    }
}
