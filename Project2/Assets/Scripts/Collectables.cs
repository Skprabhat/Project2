using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Collectables : MonoBehaviour
{
    public GameObject PickupEffect;
   // public ScoreManager instance;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Instantiate(PickupEffect, collision.gameObject.transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().play("Pickup");
            Destroy(collision.gameObject);
            FindObjectOfType<ScoreManager>().IncreaseCoin();
           
        }
    }
}
