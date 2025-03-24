using System;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public PlantData plantData;
    
    public void DestroySeed()
    {
        Destroy(this.gameObject);
    }
}
