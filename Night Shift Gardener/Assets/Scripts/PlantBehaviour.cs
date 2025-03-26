using System;
using System.Collections;
using UnityEngine;

public class PlantBehaviour : InventoryItem
{
    public PlantData plantData;
    // [SerializeField] private SpotCharacter spotCharacter;
    public bool isHarvestable;
    public Action<PlantBehaviour> getHarvested;
    public SpriteRenderer spriteRenderer;
    public float growingModifier = 1f;
    public bool isWatered;
    
    private Coroutine _growingCoroutine;  
    private float _elapsedTime = 0f;
    private bool _isGrowing = false; 

    private void Start()
    {
        // spotCharacter.characterSpotted += OnCharacterSpotted;
        InitializePlant(plantData);
    }

    public void Harvest()
    {
        getHarvested?.Invoke(this);
        DestroyItem();
    }

    public void Water()
    {
        if (!_isGrowing) return;
        if (isWatered) return;
        
        growingModifier *= 2;
        isWatered = true;
    }
    
    private void OnCharacterSpotted(CharacterBehaviour character)
    {
        
    }

    public PlantData InitializePlant(PlantData plant)
    {
        if (plant == null) return null;
        plantData = plant;
        itemName = plantData.name;
        _isGrowing = true;
        isWatered = false;
        
        if (_growingCoroutine != null) StopCoroutine(_growingCoroutine);
        _growingCoroutine = StartCoroutine(StartPlantGrow());

        return plant;
    }

    private IEnumerator StartSeedDecay()
    {
        yield return new WaitForSeconds(plantData.GetGrowingTime(growingModifier));
        isHarvestable = false;
        spriteRenderer.sprite = plantData.decaySprite;
    }
    private IEnumerator StartPlantGrow()
    {
        isHarvestable = false;
        _isGrowing = true;
        
        int totalStages = plantData.growStagesSprites.Length;
        float totalTime = plantData.GetGrowingTime(growingModifier);
        float timePerStage = totalTime / totalStages;
        _elapsedTime = 0f;

        for (int i = 0; i < totalStages; i++)
        {
            spriteRenderer.sprite = plantData.growStagesSprites[i];
            float stageStartTime = _elapsedTime;

            while (_elapsedTime - stageStartTime < (plantData.GetGrowingTime(growingModifier) / totalStages))
            {
                yield return null;
                _elapsedTime += Time.deltaTime;
            }
        }

        spriteRenderer.sprite = plantData.growStagesSprites[totalStages - 1];
        isHarvestable = true;
        _isGrowing = false;
    }
}
