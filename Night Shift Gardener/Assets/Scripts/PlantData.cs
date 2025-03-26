using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "PlantData", menuName = "Scriptable Objects/PlantData")]
public class PlantData : ScriptableObject
{
    public string plantName;
    public Sprite[] growStagesSprites;
    public Sprite decaySprite;
    [SerializeField] private float growingTime;
    [SerializeField] private  float decayTime;
    

    
    public float GetGrowingTime(float growingModifier)
    {
        return growingTime / growingModifier;
    }
    
    public float GetDecayTime(float decayModifier)
    {
        return decayModifier / decayTime;
    }
}
 