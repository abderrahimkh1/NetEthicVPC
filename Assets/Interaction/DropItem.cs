using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class DropItem : MonoBehaviour
{
    public Transform DropPoint;
    public Item item;
    
    public void DropIt()
    {
        DropPoint = GameObject.FindGameObjectWithTag("Drop").transform;
        GameObject droppedItem = Instantiate(item.prefab, DropPoint.position, Quaternion.identity);

        // Apply force to make the item jump out of the player
        Rigidbody rb = droppedItem.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(DropPoint.forward * 10f, ForceMode.Impulse);
            InventoryManager.Instance.Remove(item);
            Destroy(gameObject);
        }
        
    }
}
