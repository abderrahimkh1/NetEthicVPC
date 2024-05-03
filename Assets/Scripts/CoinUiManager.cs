using TMPro;
using UnityEngine;

public class CoinUIManager : MonoBehaviour
{
    public static CoinUIManager Instance;

    public TextMeshProUGUI coinCountText;

    void Awake()
    {
        // Ensure there is only one instance of CoinUIManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            // If an instance already exists, destroy this one
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Subscribe to the event for coin count change
        GameManager.OnCoinCountChanged += UpdateCoinCountUI;
    }

    public void UpdateCoinCountUI(int newCoinCount)
    {
        // Update the displayed coin count
        coinCountText.text = "Coins: " + newCoinCount;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the event to avoid memory leaks
        GameManager.OnCoinCountChanged -= UpdateCoinCountUI;
    }
}
