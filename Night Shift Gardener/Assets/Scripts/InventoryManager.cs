using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // public List<InventoryItem> inventoryItems;
    public Dictionary<string, int> inventoryItems = new Dictionary<string, int>();
    public Action<string> inventoryUpdated;
    
    public bool TryAddItem(string key, int amount)
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
}