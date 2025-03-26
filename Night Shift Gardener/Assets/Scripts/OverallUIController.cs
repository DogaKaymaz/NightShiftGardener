using System;
using TMPro;
using UnityEngine;

public class OverallUIController : MonoBehaviour
{
    public TextMeshProUGUI text;
    public CharacterBehaviour characterBehaviour;

    private void Start()
    {
        characterBehaviour.characterInteractedPlant += OnCharacterInteractedPlant;
        characterBehaviour.characterExitPlant += OnCharacterExitPlant;
        OnCharacterExitPlant();
    }

    private void OnCharacterExitPlant()
    {
        text.enabled = false;
    }

    private void OnCharacterInteractedPlant(PlantBehaviour plant)
    {
        text.enabled = true;
        if (plant.isHarvestable)text.SetText("You can harvest the plant by pressing E!");
        if (!plant.isWatered && !plant.isHarvestable) text.SetText("You can water the plant by pressing E.");
        if(plant.isWatered && !plant.isHarvestable) text.SetText("You already watered the plant!");
    }
}
