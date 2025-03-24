using System;
using System.Collections;
using UnityEngine;

public class PlantingSpot : MonoBehaviour
{
    private Seed _seed;
    private bool _hasSeed;
    private bool _isSeedThirsty;
    private bool _isHarvestable;

    private Seed PlantSeed(Seed seed)
    {
        if (_hasSeed) return null;
        _seed = seed;
        Instantiate(_seed, transform);
        StartCoroutine(StartSeedGrowing());
        return _seed;
    }

    private IEnumerator StartSeedGrowing()
    {
        yield return new WaitForSeconds(_seed.plantData.GetGrowingTime());
    }
    
}
