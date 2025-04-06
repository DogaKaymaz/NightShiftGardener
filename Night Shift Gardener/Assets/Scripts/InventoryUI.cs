using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public InventorySlotUI slotPrefab;
    [SerializeField] private List<QualityFrame> itemFrames;
    private Dictionary<InventoryItem.ItemQuality, Sprite> itemFramesDictionary= new Dictionary<InventoryItem.ItemQuality, Sprite>();

    [SerializeField] private Transform inventorySlotsParentTransform;
    private void OnInitialize()
    {
        itemFramesDictionary.Clear();
     
        if (itemFrames == null) return;
        
        foreach (QualityFrame frame in itemFrames)
            itemFramesDictionary.TryAdd(frame.itemQuality, frame.itemFrame);
    }

    public void InitializeInventoryUI(TraderBehaviour trader)
    {
        OnInitialize();
        
        foreach (Transform child in inventorySlotsParentTransform)
        {
            Destroy(child.gameObject);
        }
        
        var inventory = trader.GetInventory();

        foreach (KeyValuePair<InventoryItem,int> pair in inventory)
        {
            InventoryItem item = pair.Key;
            int amount = pair.Value;
            
            InventoryItem.ItemQuality itemQuality = item.GetItemQuality();
            
            var itemUI = Instantiate(slotPrefab, inventorySlotsParentTransform);
            itemUI.InitializeSLot(
                item.GetItemIcon(),
                itemFramesDictionary[item.GetItemQuality()],
                item.GetItemName(),
                item.GetItemQuality().ToString(),
                item.GetItemPrice().ToString());
            // itemUI.SetItemIcon(item.GetItemIcon());
            // itemUI.SetItemIcon(itemFramesDictionary[item.GetItemQuality()]);
            // itemUI.SetItemName(item.GetItemName());
            // itemUI.SetItemQuality(itemQuality.ToString());
            // itemUI.SetItemCost(item.GetItemPrice());
        }
    }
    
    [System.Serializable]
    protected class QualityFrame
    {
        public InventoryItem.ItemQuality itemQuality;
        public Sprite itemFrame;
    }
}
