using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public GameObject backpackPrefab;
    public Transform backpackSpawnPoint;

    private bool questActive = false;
    private bool questCompleted = false; // Added variable to track quest completion status
    public GameObject dialoguetest;
    // Method to accept the quest
    public void AcceptQuest()
    {
        questActive = true;
        questCompleted = false; // Reset quest completion status when accepting the quest
        EnableBackpack();
    }

    // Method to enable the backpack
    void EnableBackpack()
    {
        backpackPrefab.SetActive(true);
        backpackPrefab.transform.position = backpackSpawnPoint.position;
    }

    // Method to handle player interaction with the backpack
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player interacted with the backpack!");
        if (other.CompareTag("Player") && questActive && !questCompleted)
        {
            // Perform interaction logic
            CompleteQuest(); // Complete the quest
        }
    }

    // Method to complete the quest
    public void CompleteQuest()
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
    public bool IsQuestActive()
    {
        return questActive;
    }
}
