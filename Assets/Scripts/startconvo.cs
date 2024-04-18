using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
public class startconvo : MonoBehaviour
{
    [SerializeField] private NPCConversation myConv;
    [SerializeField] public bool Quest;
    public QuestManager QuestManager;
    public bool questcompleted;

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
                questcompleted = QuestManager.questCompleted; //on dialogue start yekhou value 
            }
            else
            {
                Debug.LogWarning("QuestManager reference is not set.");
            }
            ConversationManager.Instance.StartConversation(myConv);
            ConversationManager.Instance.SetBool("quest", Quest);
            ConversationManager.Instance.SetBool("completedQuest", questcompleted);
        }
    }
}