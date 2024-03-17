using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public GameObject backpackPrefab;
    public Transform backpackSpawnPoint;

    private bool questActive = false;
    private bool questCompleted = false; // Added variable to track quest completion status

    // Method to accept the quest
    public void AcceptQuest()
    {
        questActive = true;
        questCompleted = false; // Reset quest completion status when accepting the quest
        SpawnBackpack();
    }

    // Method to spawn the backpack
    void SpawnBackpack()
    {
        Instantiate(backpackPrefab, backpackSpawnPoint.position, Quaternion.identity);
    }

    // Method to handle player interaction with the backpack
   public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player interacted with the backpack!");
        if (other.CompareTag("Player") && questActive && !questCompleted)
        {
            
            Destroy(other.gameObject); // Destroy the backpack
            CompleteQuest(); // Complete the quest
        }
    }

    // Method to complete the quest
    void CompleteQuest()
    {
        questActive = false;
        questCompleted = true; // Mark the quest as completed
        // Display completion message or trigger other events
    }

    // Method to check if the quest is completed
    public bool IsQuestCompleted()
    {
        return questCompleted;
    }
}
