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
    [SerializeField] private Image itemCostResourceVisual;
    [SerializeField] private TextMeshProUGUI itemAmount;

    public DraggableItem draggableItem;
    
    public void InitializeSLot(InventoryItem item, Sprite itemIcon, Sprite itemFrame, string itemName, string itemQuality, string itemCost, Sprite itemCostResourceVisual)
    {
        this.itemIcon.sprite = itemIcon;
        this.itemFrame.sprite = itemFrame;
        this.itemName.SetText(itemName);
        this.itemQuality.SetText(itemQuality);
        this.itemCost.SetText(itemCost);
        this.itemCostResourceVisual.sprite = itemCostResourceVisual;

        if(draggableItem != null) draggableItem.inventoryItem = item; 
        if(itemAmount != null) itemAmount.SetText(item.amount.ToString());
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