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

    public void InitializeInventoryUI(List<InventoryItem> inventory)
    {
        OnInitialize();
        
        foreach (InventoryItem item in inventory)
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
            
            if (item.amount <= 0)
            {
                Destroy(itemUI.gameObject);
            }
        }
    }
}
