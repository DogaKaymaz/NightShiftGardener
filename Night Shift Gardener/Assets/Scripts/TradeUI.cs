using System;
using UnityEngine;

public class TradeUI : MonoBehaviour
{
    [SerializeField] private TraderBehaviour trader;
    [SerializeField] private GameObject tradeUI;

    private void Start()
    {
        OnTraderInteractedCharacter();
        trader.traderInteractedCharacter += OnTraderInteractedCharacter;
    }

    private void OnTraderInteractedCharacter()
    {
        tradeUI.SetActive(!tradeUI.activeSelf);
    }
}
