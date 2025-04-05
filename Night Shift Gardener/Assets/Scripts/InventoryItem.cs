using UnityEngine;
using UnityEngine.Serialization;

public class InventoryItem : ScriptableObject
{
    [SerializeField] private int itemID;
    [SerializeField] private ItemQuality itemQuality;
    [SerializeField] private float itemQualityModifier = 2f;
    [SerializeField] private float itemBasePrice;
    

    public string GetItemID()
    {
        return itemID.ToString();
    }
    public int GetItemIDint()
    {
        return itemID;
    }
    public ItemQuality GetItemQuality()
    {
        return itemQuality;
    }
    public void ImproveQuality()
    {
        if (itemQuality < ItemQuality.Legendary)
            itemQuality++;
    }
    public void DegradeQuality()
    {
        if (itemQuality > ItemQuality.Poor)
            itemQuality--;
    }
    public float GetItemPrice()
    {
        return itemBasePrice + (itemQualityModifier * (float)itemQuality);
    }
    public enum ItemQuality
    {
        Poor = 0,
        Common = 1,
        Epic = 2,
        Legendary = 3
    }
}