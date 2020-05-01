using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    //public GameObject player;
    public GameObject destination;


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            collision.gameObject.SetActive(false);
            //var GOB = collision.gameObject;
            Debug.Log("ddoo");
            collision.gameObject.transform.position = new Vector2(destination.transform.position.x + 2f, destination.transform.position.y); Invoke("Function", 1f);
            collision.gameObject.SetActive(true);
        }
    }
}
