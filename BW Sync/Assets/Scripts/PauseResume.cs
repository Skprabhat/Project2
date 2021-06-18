using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseResume : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject PauseButton;

    bool GamePaused;


    // Start is called before the first frame update
    void Start()
    {
        GamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GamePaused == true) 
        {
            Time.timeScale = 0;
        }
        if (GamePaused == false) 
        {
            Time.timeScale = 1;
        }
    }

    public void PauseGame()
    {
        GamePaused = true;
        PausePanel.SetActive(true);
        PauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        GamePaused = false;
        PausePanel.SetActive(false);
        PauseButton.SetActive(true);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu Scene");
    }
}
