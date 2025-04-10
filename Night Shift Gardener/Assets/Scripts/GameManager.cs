using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static InventoryManager mcInventoryManager;
    public static ResourceManager mcResourceManager;

    private void Awake()
    {
        mcInventoryManager = GetComponent<InventoryManager>();
        mcResourceManager = GetComponent<ResourceManager>();
    }
}
