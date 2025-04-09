using UnityEngine;

public class ItemData : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private Sprite itemIcon;
    [SerializeField] private float itemQualityModifier = 2f;
    [SerializeField] private float itemBasePrice;
    public ResourceType itemPriceResourceType;
    
    public string GetItemName()
    {
        return itemName;
    }
    public Sprite GetItemIcon()
    {
        return itemIcon;
    }
    public float GetItemPrice(ItemQuality itemQuality)
    {
        return itemBasePrice + (itemQualityModifier * (float)itemQuality);
    }
}