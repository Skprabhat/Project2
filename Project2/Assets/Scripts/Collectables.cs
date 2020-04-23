using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Collectables : MonoBehaviour
{
    [SerializeField]
    public int score;
    public GameObject PickupEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Instantiate(PickupEffect, collision.gameObject.transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().play("Pickup");
            score += 100;
            Destroy(collision.gameObject);
        }
    }
}
