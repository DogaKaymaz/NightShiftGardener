using System;
using UnityEngine;

public class Seed : InventoryItem
{
    public PlantData plantData;
    
    public void DestroySeed()
    {
        Destroy(this);
    }
}