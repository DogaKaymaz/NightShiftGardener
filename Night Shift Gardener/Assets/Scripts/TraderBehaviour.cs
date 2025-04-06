using System;
using System.Collections.Generic;
using UnityEngine;

public class TraderBehaviour : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;
    public Action<InventoryItem> tradeHappened;
    public Action traderInteractedCharacter;
    
    public bool TryTrade(InventoryItem inventoryItem, InventoryItem id, int amount)
    {
        if (inventoryManager.TrySpend(id, amount))
        {
            tradeHappened?.Invoke(inventoryItem);
            return true;
        }
        
        return false;
    }

    public Dictionary<InventoryItem, int> GetInventory()
    {
        return inventoryManager.GetInventory();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out CharacterBehaviour character))
        {
            traderInteractedCharacter?.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out CharacterBehaviour character))
        {
            traderInteractedCharacter?.Invoke();
        }
    }
}