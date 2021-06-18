using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountDown : MonoBehaviour
{
    public GameObject Timer;
    public int secondsLeft = 30;
    public bool TakingAway = false;
    public GameObject GameOver;
    public GameObject Score;

    void Start()
    {
        Timer.GetComponent<Text>().text = "00:" + secondsLeft;
    }
    void Update()
    {
        if (TakingAway == false && secondsLeft > 0)
        {
            StartCoroutine(Timertake());
        }
        
    }
    IEnumerator Timertake()
    {
        TakingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if (secondsLeft < 10)
        {
            Timer.GetComponent<Text>().text = "00:0" + secondsLeft;
        }
        else
        {
            Timer.GetComponent<Text>().text = "00:" + secondsLeft;
        }
        TakingAway = false;

        if (secondsLeft == 0) 
        {
            Timer.SetActive(false);
            Score.SetActive(false);
            GameOver.SetActive(true);
        }
    }
}
