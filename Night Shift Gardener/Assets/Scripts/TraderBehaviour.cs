using System;
using System.Collections.Generic;
using UnityEngine;

public class TraderBehaviour : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;
    public Action<InventoryItem> tradeHappened;
    public Action traderInteractedCharacter;
    
    public void Trade(InventoryItem item, int amount)
    {
        if (!GameManager.mcResourceManager.mcResourceData.TryConsumeResource(item.itemData.itemPriceResourceType, amount))
            return;
        GameManager.mcInventoryManager.AddItem(item, amount);
        tradeHappened?.Invoke(item);
    }

    public InventoryManager GetInventoryManager()
    {
        return inventoryManager;
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