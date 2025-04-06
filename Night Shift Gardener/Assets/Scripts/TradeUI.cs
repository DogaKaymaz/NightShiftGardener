using System;
using UnityEngine;

public class TradeUI : MonoBehaviour
{
    [SerializeField] private TraderBehaviour trader;
    [SerializeField] private GameObject tradeUI;
    [SerializeField] private InventoryUI inventoryUI;

    private void Start()
    {
        OnTraderInteractedCharacter();
        trader.traderInteractedCharacter += OnTraderInteractedCharacter;
    }

    private void OnTraderInteractedCharacter()
    {
        tradeUI.SetActive(!tradeUI.activeSelf);
        if (tradeUI.activeSelf) return;
        
        CloseInventory();
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
        inventoryUI.InitializeInventoryUI(trader);
    }
    public void CloseInventory()
    {
        inventoryUI.gameObject.SetActive(false);   
    }
}
