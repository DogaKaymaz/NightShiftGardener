using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public InventorySlotUI slotPrefab;
    [SerializeField] private Transform inventorySlotsParentTransform;
    
    private void OnInitialize()
    {
        foreach (Transform child in inventorySlotsParentTransform)
        {
            Destroy(child.gameObject);
        }
    }

    public void InitializeInventoryUI(TraderBehaviour trader)
    {
        OnInitialize();
        
        var inventory = trader.GetInventory();
        
        foreach (InventoryItem item in inventory)
        {
            ItemQuality itemQuality = item.GetItemQuality();
            
            var itemUI = Instantiate(slotPrefab, inventorySlotsParentTransform);
            itemUI.InitializeSLot(
                item.itemData.GetItemIcon(),
                ItemQualityDataManager.Instance.GetSlotFrame(itemQuality),
                item.itemData.GetItemName(),
                itemQuality.ToString(),
                item.itemData.GetItemPrice(itemQuality).ToString());
        }
    }
}
