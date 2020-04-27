using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int coins;
    public int thisGameCoins;
    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("Coins", 0);
    }
    public void IncreaseCoin()
    {
        thisGameCoins += 100;
    }
    public void GameOver()
    {
        PlayerPrefs.SetInt("Coins", coins + thisGameCoins); //saving and adding coins
        PlayerPrefs.Save();
    }
}
