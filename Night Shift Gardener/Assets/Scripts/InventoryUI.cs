using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public InventorySlotUI slotPrefab;
    [SerializeField] private Transform inventorySlotsParentTransform;
    
    private void OnInitialize(InventoryManager inventory, TraderBehaviour trader)
    {
        foreach (Transform child in inventorySlotsParentTransform)
        {
            Destroy(child.gameObject);
        }
        
        foreach (InventoryItem item in inventory.ownedItems)
        {
            ItemQuality itemQuality = item.GetItemQuality();

            var itemUI = Instantiate(slotPrefab, inventorySlotsParentTransform);
            itemUI.InitializeSLot(
                item,
                item.itemData.GetItemIcon(),
                ItemQualityDataManager.Instance.GetSlotFrame(itemQuality),
                item.itemData.GetItemName(),
                itemQuality.ToString(),
                item.itemData.GetItemPrice(itemQuality).ToString(),
                item.itemData.itemPriceResourceType.icon);
            
            if (trader != null)
            {
                itemUI.triedBuyItem += trader.Trade;
            }
        }
    }

    public void InitializeInventoryUI(InventoryManager inventory)
    {
        OnInitialize(inventory, null);
    }

    public void InitializeInventoryUI(InventoryManager inventory, TraderBehaviour trader)
    {
        OnInitialize(inventory, trader);
    }
}