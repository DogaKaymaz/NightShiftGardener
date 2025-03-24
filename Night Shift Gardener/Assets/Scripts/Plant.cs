using System.Collections;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public PlantType plantType;
    public bool harvestable;
    public bool isGrowing;
    
    public IEnumerator PlantSeed()
    {
        if(harvestable) yield break;
        if(isGrowing) yield break;

        yield return new WaitForSeconds(plantType.growingTime);
        Instantiate(plantType);
    }
}
