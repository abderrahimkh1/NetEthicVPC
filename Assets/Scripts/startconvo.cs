using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
public class startconvo : MonoBehaviour
{
    [SerializeField] private NPCConversation myConv;
    [SerializeField] private NPCConversation myConv2;
    [SerializeField] private NPCConversation myConv3;
    [SerializeField] public bool Quest;
    public QuestManager QuestManager;
    public bool quest1completed;
    public bool quest2completed;

    private bool inRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
            Debug.Log("enter");
        }
    }
    public void setActiveQest()
    { Quest = true; }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
        }
    }

    private void Update()
    {
        if (inRange && Input.GetKeyUp(KeyCode.E))
        {
            if (QuestManager != null)
            {
                quest1completed = QuestManager.quest1Completed; //on dialogue start yekhou value 
                quest2completed = QuestManager.quest2Completed; //on dialogue start yekhou value 
            }
            else
            {
                Debug.LogWarning("QuestManager reference is not set.");
            }
            if (!quest1completed && !quest2completed)
            {
                ConversationManager.Instance.StartConversation(myConv);
            }
            else if (quest1completed && !quest2completed)
            {
                ConversationManager.Instance.StartConversation(myConv2);
            }
            else
            {
                ConversationManager.Instance.StartConversation(myConv3);
            }
            
            //ConversationManager.Instance.SetBool("quest", Quest);
            //ConversationManager.Instance.SetBool("completedQuest", questcompleted);
        }
        if (quest1completed)
        {
            if (InventoryManager.Instance.HasItem("backpack") == true)
            {
                InventoryManager.Instance.RemoveWithName("backpack");
                InventoryManager.Instance.ListItems();
            }

        }
    }
}