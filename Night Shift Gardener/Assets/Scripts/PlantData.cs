using UnityEngine;

[CreateAssetMenu(fileName = "PlantData", menuName = "Scriptable Objects/PlantData")]
public class PlantData : ScriptableObject
{
    public string plantName;
    [SerializeField] private float growingTime;
    [SerializeField] private  float growingModifier = 1f;
    [SerializeField] private  float decayTime;
    [SerializeField] private  float decayModifier = 1f;

    
    public float GetGrowingTime()
    {
        return growingModifier * growingTime;
    }
    
    public float GetDecayTime()
    {
        return decayModifier * decayTime;
    }
}
 