using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject GameOverMenu;
    bool isPause;
    public Slider oxygen;
    public Player1 p;
    public Text coin;
    // Start is called before the first frame update
    void Start()
    {
        oxygen.value = p.waterTimer;
    }
    // Update is called once per frame
    void Update()
    {
        coin.text = FindObjectOfType<ScoreManager>().thisGameCoins.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
        }
        if (isPause)
        {
            PauseMenu.SetActive(true);
            //Time.timeScale = 0;
        }
        else
        {
            PauseMenu.SetActive(false);
            //Time.timeScale = 1;
        }
        //setting slidedr value to waterTimer from PLyer script
        oxygen.value = p.waterTimer;
    }
}
