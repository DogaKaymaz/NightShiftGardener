using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class PlantingSpot : MonoBehaviour
{
    // [SerializeField] private Seed seed;
    [SerializeField] private PlantBehaviour plantBehaviour;
    [SerializeField] private PlantData plantData;
    // private bool _hasSeed;

    private void Start()
    {
        PlantSeed(plantBehaviour.plantData);
    }

    public void PlantSeed(PlantData plantData)
    {
        // if (_hasSeed) return;
        // this.seed = seed;

        this.plantData = plantData;
        var newPlant = Instantiate(plantBehaviour, transform);
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
        PlantSeed(plant.plantData);
    }
}