using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class InventoryItem
{
    public ItemData itemData;
    public ItemQualityData itemQualityData; 
    private ItemQuality _itemQuality; 
    public int amount;
    private bool _qualityUpgraded = false;
    public string GetIdemID()
    {
        SetItemQuality();
        return itemData.name + "_" + _itemQuality;
    }
    public void SetItemQuality(ItemQuality targetQuality)
    {
        _itemQuality = targetQuality;
        _qualityUpgraded = true;
    }
    private void SetItemQuality()
    {
        if(_qualityUpgraded) return;
        _itemQuality = itemQualityData != null ? itemQualityData.itemQuality : default;
    }
    public ItemQuality GetItemQuality()
    {
        SetItemQuality();
        return _itemQuality;
    }
    public void ImproveQuality()
    {
        if (itemQualityData.itemQuality < ItemQuality.Legendary)
            _itemQuality++;
    }
    public void DegradeQuality()
    {
        if (itemQualityData.itemQuality > ItemQuality.Poor)
            _itemQuality--;
    }
}