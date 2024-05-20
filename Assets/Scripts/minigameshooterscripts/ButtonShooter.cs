using UnityEngine;

public class ButtonShooter : MonoBehaviour
{
    public GameObject buttonPrefab; // Prefab for the button object
    public RectTransform uiPanel; // Reference to the UI panel where buttons will be placed
    public float shootInterval = 1f; // Time interval between each button shoot
    public float shootSpeed = 5f; // Speed of button movement
    public float countdownDuration = 30f; // Duration for the button shooting

    private float nextShootTime; // Time when the next button shoot will occur
    private float countdownTimer; // Countdown timer

    void Start()
    {
        nextShootTime = Time.time + shootInterval; // Initialize next shoot time
        countdownTimer = countdownDuration; // Initialize countdown timer
    }

    void Update()
    {
        // Update the countdown timer
        countdownTimer -= Time.deltaTime;

        // Check if the countdown timer has ended
        if (countdownTimer <= 0)
        {
            return; // Stop shooting buttons when the countdown ends
        }

        // Check if it's time to shoot the next button
        if (Time.time >= nextShootTime)
        {
            ShootButton();
            nextShootTime = Time.time + shootInterval; // Update next shoot time
        }
    }

    void ShootButton()
    {
        // Instantiate the button prefab at a random position outside the UI panel
        Vector3 spawnPosition = GetRandomSpawnPositionOutsidePanel();
        GameObject button = Instantiate(buttonPrefab, spawnPosition, Quaternion.identity);

        // Set the parent of the button to the UI panel
        button.transform.SetParent(uiPanel, false);

        // Get the direction towards the center of the UI panel
        Vector3 direction = (uiPanel.position - spawnPosition).normalized;

        // Add force to the button to shoot it towards the center of the UI panel
        Rigidbody2D rb = button.GetComponent<Rigidbody2D>();
        rb.velocity = direction * shootSpeed;

        // Destroy the button after 15 seconds to prevent infinite accumulation
        Destroy(button, 15f);
    }

    Vector3 GetRandomSpawnPositionOutsidePanel()
    {
        // Get the size of the UI panel
        Vector2 panelSize = uiPanel.sizeDelta;

        // Calculate random spawn position outside the UI panel within the visible area of the screen
        float x = Random.Range(panelSize.x * 0.5f, Screen.width - panelSize.x * 0.5f);
        float y = Random.Range(0, Screen.height);
        Vector3 spawnPosition = new Vector3(x, y, 0f);

        return spawnPosition;
    }
}
