using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InventorySystem inventorySystem;
    [SerializeField] private GameObject m_slotPrefab;
    void Start()
    {
        inventorySystem = FindObjectOfType<InventorySystem>();
        OnUpdateInventory();
    }

    public void OnUpdateInventory()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        DrawInventory();
    }

    private void DrawInventory()
    {
        foreach (InventoryItem item in inventorySystem.inventory)
        {
            AddInventorySlot(item);
        }
    }

    public void AddInventorySlot(InventoryItem item)
    {
        GameObject obj = Instantiate(m_slotPrefab);
        obj.transform.SetParent(transform, false);

        Slot slot = obj.GetComponent<Slot>();
        slot.Set(item);
    }
}
