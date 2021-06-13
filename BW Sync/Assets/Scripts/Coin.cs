using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float lifeTime = 3f;

    void Start()
    {
        DestroyAfter(lifeTime);
    }

   void DestroyAfter(float time)
    {
        Destroy(gameObject, time);
    }
}
