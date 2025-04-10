using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUIManager : MonoBehaviour
{
    [SerializeField] private InventoryUI inventoryUI;

    public ResourceType type;
    public Image icon;
    public TextMeshProUGUI resourceAmount;

    public ResourceManager mcResourceManager;
    // public InventoryManager mcInventoryManager;

    private void Awake()
    {
    }

    private void Start()
    {
        InitializeUI();
        UpdateUI();

    }

    private void InitializeUI()
    {
        mcResourceManager.mcResourceData.ResourceAmountChanged -= McResourceManagerOnResourceAmountChanged;
        mcResourceManager.mcResourceData.ResourceAmountChanged += McResourceManagerOnResourceAmountChanged;
        
        GameManager.mcInventoryManager.inventoryUpdated += OnInventoryUpdated;
    }

    private void OnInventoryUpdated(InventoryItem obj)
    {
        inventoryUI.InitializeInventoryUI(GameManager.mcInventoryManager);
    }

    private void McResourceManagerOnResourceAmountChanged(ResourceType type, float amount)
    {
        UpdateResourceAmountUI(amount);
    }

    private void OnDestroy()
    {
        mcResourceManager.mcResourceData.ResourceAmountChanged -= McResourceManagerOnResourceAmountChanged;
    }
    
    public void UpdateUI()
    {
        if(icon) icon.sprite = type.icon;
    }

    public void UpdateResourceAmountUI(float amount)
    {
        if(resourceAmount) resourceAmount.SetText(amount.ToString());
    }

    public void ChangeInventoryVisibility()
    {
        if (inventoryUI.gameObject.activeSelf)
        {
            CloseInventory();
            return;
        } 
        OpenInventory();
    }
    
    public void OpenInventory()
    {
        inventoryUI.gameObject.SetActive(true);
        inventoryUI.InitializeInventoryUI(GameManager.mcInventoryManager);
    }
    public void CloseInventory()
    {
        inventoryUI.gameObject.SetActive(false);   
    }
}
