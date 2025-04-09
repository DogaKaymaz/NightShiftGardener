using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ResourceManager : MonoBehaviour
{
    [SerializeField] private List<ResourceType> resourceTypes;
    public ResourceData mcResourceData;
    public int number = 0;

    private void Start()
    {
        mcResourceData.InitializeResources(resourceTypes); 
    }

    public ResourceData InitializeResourceData()
    {
        ResourceData resourceData = new ResourceData();
        foreach (ResourceType type in resourceTypes) 
        {
            resourceData.AddResource(type, 0f);
        }
        return resourceData;
    }
    
    private void Update()
    {
        // they are for test purposes shortcuts, we can delete them later
        // if (Input.GetKeyDown(KeyCode.E)) mcResourceData.AddResource(resourceTypes[number], 15);
        // if (Input.GetKeyDown(KeyCode.C)) mcResourceData.ConsumeResource(resourceTypes[number], 3f);
    }
}