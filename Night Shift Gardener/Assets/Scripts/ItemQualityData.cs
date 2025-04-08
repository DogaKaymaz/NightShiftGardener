using UnityEngine;

[CreateAssetMenu(fileName = "ItemQualityData", menuName = "Scriptable Objects/Items/ItemQualityData")]
public class ItemQualityData : ScriptableObject
{
    public ItemQuality itemQuality;
    public Sprite slotFrameSprite;
}

public enum ItemQuality
{
    Poor = 0,
    Common = 1,
    Epic = 2,
    Legendary = 3
}