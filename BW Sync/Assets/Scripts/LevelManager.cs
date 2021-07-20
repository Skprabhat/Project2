using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public GameObject gameDone;
    
    void Start()
    {
        PlayerPrefs.SetInt("SceneIndex", SceneManager.GetActiveScene().buildIndex);
        Debug.Log(SceneManager.GetActiveScene().name );
    }

    public void LoadNextLvl()
    {
        Debug.Log("inside load lvl");
        int i = PlayerPrefs.GetInt("SceneIndex");

        if(i < 11)
        {
            SceneManager.LoadScene(i + 1);
        }
        else
        {
            gameDone.SetActive(true); 
        }
    }

    public void TimeTrail()
    {
        int i = Random.Range(12,15);
        SceneManager.LoadScene(i);
    }
}
