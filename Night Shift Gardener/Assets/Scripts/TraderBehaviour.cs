using System;
using System.Collections.Generic;
using UnityEngine;

public class TraderBehaviour : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;
    public Action<InventoryItem> tradeHappened;
    
    public bool TryTrade(InventoryItem inventoryItem, string id, int amount)
    {
        if (inventoryManager.TrySpend(id, amount))
        {
            tradeHappened?.Invoke(inventoryItem);
            return true;
        }
        
        return false;
    }
}