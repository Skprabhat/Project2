using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scenemanager : MonoBehaviour
{
   public void StartGame()
    {
        SceneManager.LoadScene("DefaultLvl_1");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
