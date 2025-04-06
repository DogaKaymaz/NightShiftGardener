using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private Image itemFrame;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemQuality;
    [SerializeField] private TextMeshProUGUI itemCost;

    public void InitializeSLot(Sprite itemIcon, Sprite itemFrame, string itemName, string itemQuality, string itemCost)
    {
        this.itemIcon.sprite = itemIcon;
        this.itemFrame.sprite = itemFrame;
        this.itemName.SetText(itemName);
        this.itemQuality.SetText(itemQuality);
        this.itemCost.SetText(itemCost);
    }
    
    public void SetItemIcon(Sprite sprite)
    {
        itemIcon.sprite = sprite;
    }
    public void SetItemFrame(Sprite sprite)
    {
        itemFrame.sprite = sprite;
    }
    public void SetItemName(string thisItemName)
    {
        itemName.SetText(thisItemName);
    }
    public void SetItemQuality(string quality)
    {
        itemQuality.SetText(quality);
    }
    public void SetItemCost(float cost)
    {
        itemCost.SetText(cost.ToString());
    }
}