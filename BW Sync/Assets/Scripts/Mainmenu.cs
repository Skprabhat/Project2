using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public void QuitGame()
    {
       // Debug.Log("QUIT!");
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu Scene");
    }
    public void Restart1()
    {
        
        SceneManager.LoadScene("Level 1");
    }
    public void Restart2()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void Restart3()
    {
        SceneManager.LoadScene("Level 3");
    }
    public void Restart4()
    {
        SceneManager.LoadScene("Level 4");
    }
    public void Restart5()
    {
        SceneManager.LoadScene("Level 5");
    }
    public void Restart6()
    {
        SceneManager.LoadScene("Level 6");
    }
    public void Restart7()
    {
        SceneManager.LoadScene("Level 7");
    }
    public void Restart8()
    {
        SceneManager.LoadScene("Level 8");
    }
    public void Restart9()
    {
        SceneManager.LoadScene("Level 9");
    }
    public void Restart10()
    {
        SceneManager.LoadScene("Level 10");
    }
    public void Restart11()
    {
        SceneManager.LoadScene("Level 11");
    }
    public void RestartTime1()
    {
        SceneManager.LoadScene("Time Trial 1");
    }
    public void RestartTime2()
    {
        SceneManager.LoadScene("Time Trial 2");
    }
    public void RestartTime3()
    {
        SceneManager.LoadScene("Time Trial 3");
    }
}
