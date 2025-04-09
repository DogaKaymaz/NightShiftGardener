using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class PlantingSpot : MonoBehaviour
{
    // [SerializeField] private Seed seed;
    [SerializeField] private PlantBehaviour plantBehaviour;
    [SerializeField] private PlantData plantData;
    [SerializeField] private ItemQualityData plantQuality;
    // private bool _hasSeed;

    private void Start()
    {
        if (plantData != null && plantQuality != null)
        {
            PlantSeed(plantBehaviour.plantData, plantQuality);
        }
    }

    public void PlantSeed(PlantData plantData, ItemQualityData qualityData)
    {
        Debug.Log("????");
        // if (_hasSeed) return;
        // this.seed = seed;

        plantBehaviour.plantData = plantData;
        this.plantData = plantData;
        var newPlant = Instantiate(plantBehaviour, transform);
        newPlant.GetComponent<InventoryItemInstance>().inventoryItem = new InventoryItem()
        {
            amount = 1,
            itemData = plantData,
            itemQualityData = qualityData
        };
        newPlant.plantData = this.plantData;
        newPlant.InitializePlant(this.plantData);
        newPlant.getHarvested += OnGetHarvested;

        // this.plantData = plantBehaviour.plantData;
        // this.plantBehaviour = plantBehaviour;
        // var newPlant = Instantiate(plantBehaviour, transform);
        // newPlant.plantData = plantData;
        // plantBehaviour.InitializePlant(this.plantBehaviour.plantData);
        // plantBehaviour.getHarvested += OnGetHarvested;


        // seed.DestroySeed();
    }

    private void OnGetHarvested(PlantBehaviour plant)
    {
        plant.getHarvested -= OnGetHarvested;
        Debug.Log("start growing " + plant.plantData.name);
        PlantSeed(plant.plantData, plantQuality);
    }
}