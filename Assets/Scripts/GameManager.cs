using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int coinCount = 0;

    // Define delegate and event for coin count change
    public delegate void CoinCountChanged(int newCoinCount);
    public static event CoinCountChanged OnCoinCountChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Function to update the coin count
    public void UpdateCoinCount(int amount)
    {
        coinCount += amount;

        // Trigger the event when coin count changes
        if (OnCoinCountChanged != null)
        {
            OnCoinCountChanged(coinCount);
        }
    }
}
