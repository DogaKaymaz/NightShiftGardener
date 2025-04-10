using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<InventoryItem> ownedItems;
    public Action<InventoryItem> inventoryUpdated;
    

    public void AddItem(InventoryItem item, int amount)
    {
        InventoryItem ownedItem = ownedItems.Find(x => x.GetIdemID() == item.GetIdemID());

        if (ownedItem == null)
        {
            ownedItems.Add(item);
            item.amount = amount;
            inventoryUpdated?.Invoke(item);
        }
        else
        {
            ownedItem.amount += amount;
            inventoryUpdated?.Invoke(ownedItem);
        }
    }

    public bool TrySpend(InventoryItem item, int amount)
    {
        var ownedItem = ownedItems.Find(x => x.GetIdemID() == item.GetIdemID());

        if (ownedItem != null && ownedItem.amount >= amount)
        {
            ownedItem.amount -= amount;
            if (ownedItem.amount == 0) ownedItems.Remove(ownedItem);
            inventoryUpdated?.Invoke(ownedItem);
            return true;
        }

        return false;
    }
}