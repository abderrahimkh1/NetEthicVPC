using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karimstartconv : MonoBehaviour
{
    [SerializeField] private NPCConversation myConv;
    [SerializeField] private NPCConversation myConv2;
    [SerializeField] public bool Quest;
   

    private bool inRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
            Debug.Log("enter");
        }
    }
    
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
            if (InventoryManager.Instance.HasItem("livre") == false)
            {
                ConversationManager.Instance.StartConversation(myConv);
            }
            else
            {
                ConversationManager.Instance.StartConversation(myConv2);
                InventoryManager.Instance.RemoveWithName("livre");
                InventoryManager.Instance.ListItems();
            }
            
            }
            
        }
        
    }

