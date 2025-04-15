using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlantBehaviour : MonoBehaviour
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

    [SerializeField] private Image plantProgressionIndicator;
    [SerializeField] private Image plantWateringIndicator;
    private void Start()
    {
        // spotCharacter.characterSpotted += OnCharacterSpotted;
        InitializePlant(plantData);
    }

    public void Harvest()
    {
        getHarvested?.Invoke(this);
        Destroy(this.gameObject);
    }

    public IEnumerator StartWatering(System.Action onComplete)
    {
        
        if (!_isGrowing || isWatered) yield break;

        float elapsed = 0f;
        float duration = plantData.wateringTime;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsed / duration);
            plantWateringIndicator.fillAmount = progress;

            yield return null;
        }

        plantWateringIndicator.fillAmount = 1f;
        growingModifier *= 2;
        isWatered = true;
        onComplete?.Invoke();
    }
    
    private void OnCharacterSpotted(CharacterBehaviour character)
    {
        
    }

    public PlantData InitializePlant(PlantData plant)
    {
        if (plant == null) return null;
        plantData = plant;
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
        plantProgressionIndicator.fillAmount = 0f;

        for (int i = 0; i < totalStages; i++)
        {
            spriteRenderer.sprite = plantData.growStagesSprites[i];
            float stageStartTime = _elapsedTime;

            while (_elapsedTime - stageStartTime < (plantData.GetGrowingTime(growingModifier) / totalStages))
            {
                yield return null;
                _elapsedTime += Time.deltaTime;
                
                float fillProgress = Mathf.Clamp01(_elapsedTime / totalTime);
                plantProgressionIndicator.fillAmount = fillProgress;
            }
        }

        spriteRenderer.sprite = plantData.growStagesSprites[totalStages - 1]; 
        plantProgressionIndicator.fillAmount = 1f;

        isHarvestable = true;
        _isGrowing = false;
    }
}