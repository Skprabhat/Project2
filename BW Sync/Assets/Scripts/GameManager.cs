using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject coins;
    bool isCoinsNotActive ;
   

    void Update()
    {
        isCoinsNotActive = CheckForActiveCoins();

        if(isCoinsNotActive)
        {
            //set canvas active
            Debug.Log("coins are done");
        }
    }

    bool CheckForActiveCoins()
    {
        foreach(Transform child in coins.transform)
        {
            if(child.gameObject.activeInHierarchy)
            {
                return false;
            }
        }
        return true;

    }

}
