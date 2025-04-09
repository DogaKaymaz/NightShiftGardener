using UnityEngine;

[CreateAssetMenu(fileName = "ResourceType", menuName = "Scriptable Objects/ResourceType")]
public class ResourceType : ScriptableObject
{
     public string resourceName;
     public Sprite icon; 
     public bool isConsumable;
}
