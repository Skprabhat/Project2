using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject coins;
    bool isCoinsNotActive ;
    public LevelManager lvlManager;
    public bool isNormalMode ;
   

    void Update()
    {
        if(isNormalMode)
        {
            isCoinsNotActive = CheckForActiveCoins();

            if (isCoinsNotActive)
            {
               
                Invoke("LoadScene", 1f);
            }
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

    public void LoadScene()
    {
        Debug.Log("inside GM load scene");
        lvlManager.LoadNextLvl();
     

    }

}
