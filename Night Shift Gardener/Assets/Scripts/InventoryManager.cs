using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<InventoryEntry> ownedItems;
    private Dictionary<InventoryItem, int> inventoryItems = new Dictionary<InventoryItem, int>();
    public Action<InventoryItem> inventoryUpdated;

    private void Start()
    {
        foreach (InventoryEntry entry in ownedItems)
        {
            if (entry.item == null) continue;
            TryAddItem(entry.item, entry.amount);
        }
    }

    public bool TryAddItem(InventoryItem key, int amount)
    {
        if (inventoryItems.TryGetValue(key, out int currentAmount))
        {
            inventoryItems[key] = currentAmount + amount;
            inventoryUpdated?.Invoke(key);
            return true;
        }

        if (!inventoryItems.TryAdd(key, amount)) return false;
        
        inventoryUpdated?.Invoke(key);
        return true;
    }

    public bool TrySpend(InventoryItem key, int amount)
    {
        if (inventoryItems.TryGetValue(key, out int currentAmount) && currentAmount >= amount)
        {
            inventoryItems[key] -= amount;
            return true;
        }
        return false;
    }
    
    public Dictionary<InventoryItem, int> GetInventory()
    {
        return inventoryItems;
    }
    
    [System.Serializable]
    protected class InventoryEntry
    {
        public InventoryItem item;
        public int amount = 1;
    }
}