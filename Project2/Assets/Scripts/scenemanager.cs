using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scenemanager : MonoBehaviour
{
    public GameObject Player1;
    private GameObject Player2;
    //private void Start()
    //{
    //    Player1 = GameObject.Find("Player1");
    //   // Player1.SetActive(false);
    //    Player2 = GameObject.Find("Player2");
    //   // Player2.SetActive(true);

    //}
   
    public void StartGame()
    {
        SceneManager.LoadScene("DefaultLvl_1");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("M_M");
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void Retry1()
    {
        SceneManager.LoadScene("DefaultLvl_2");
    }
    public void MainMenu1()
    {
        SceneManager.LoadScene("M_M");
    }
    public void NextLeve2()
    {
        Debug.Log("click");
        SceneManager.LoadScene("DefaultLvl_2");
    }
    public void Retry2()
    {
        SceneManager.LoadScene("DefaultLvl_1");
    }
    public void MainMenu2()
    {
        SceneManager.LoadScene("M_M");
    }
    public void Retry3()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void Retry4()
    {
        SceneManager.LoadScene("MainScene 1");
    }
    public void NextLevel3()
    {
        //Player1.SetActive(false);
       // Player2.SetActive(true);
        SceneManager.LoadScene("MainScene 1");
    }



}
