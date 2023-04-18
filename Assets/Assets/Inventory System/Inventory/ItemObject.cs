using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData referenceItem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            OnHandlePickupItem();
        }
    }

    public void OnHandlePickupItem()
    {
        FindObjectOfType<InventorySystem>().Add(referenceItem);
        FindObjectOfType<InventoryUI>().OnUpdateInventory();
        Destroy(gameObject);
    }
}
