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
        thisGameCoins += 100; //Whatever you do to get a coin.
    }
    public void GameOver()
    {
        PlayerPrefs.SetInt("Coins", coins + thisGameCoins); //Here we are setting (saving) the coins to be sum of the old coins + the new coins!
        PlayerPrefs.Save();
    }
}
