using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class ResourceData
{
    public List<Resource> resources = new List<Resource>();
    public event Action<ResourceType, float> ResourceAmountChanged; 
    
    public float GetResourceAmount(ResourceType type)
    {
        return resources.FirstOrDefault(x => x.resourceName == type.resourceName)?.resourceAmount ?? 0f;
    }
    
    public void InitializeResources(List<ResourceType> types)
    {
        float starterAmount = 50f;
        resources = new List<Resource>();
        foreach (var t in types)
        {
            resources.Add(new Resource { resourceName = t.resourceName, resourceAmount = starterAmount }); 
            ResourceAmountChanged?.Invoke(t, starterAmount);
        }
    }
    
    public void AddResource(ResourceType type, float amount)
    {
        var resource = resources.FirstOrDefault(x => x.resourceName == type.resourceName);
        
        if (resource != null)
        {
            resource.resourceAmount += amount; 
            ResourceAmountChanged?.Invoke(type, resource.resourceAmount);
            Debug.Log(amount + " " + type.resourceName + " earned.");
            return;
        }
        
        resources.Add(new Resource { resourceName = type.resourceName, resourceAmount = amount});
        ResourceAmountChanged?.Invoke(type, amount);
        AddResource(type, amount);
    }

    public bool TryConsumeResource(ResourceType type, float amount)
    {
        var resource = resources.FirstOrDefault(x => x.resourceName == type.resourceName);

        if (type.isConsumable && resource != null)
        {
            if (resource.resourceAmount - amount < 0)
            {
                Debug.Log("no" + type.resourceName +" found to spend");
                return false;
            }
            resource.resourceAmount -= amount; 
            ResourceAmountChanged?.Invoke(type, resource.resourceAmount); 
            Debug.Log(amount + " " + type.resourceName + " spent."); 
            return true;
        }
        return false;
    }
}

[Serializable]
public class Resource
{
    public string resourceName;
    public float resourceAmount;
}