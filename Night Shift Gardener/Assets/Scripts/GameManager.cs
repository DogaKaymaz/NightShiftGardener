using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static InventoryManager mcInventoryManager;

    private void Awake()
    {
        mcInventoryManager = GetComponent<InventoryManager>();
    }
}
