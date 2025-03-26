using System;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    public InventoryManager inventoryManager;
    private PlantBehaviour _currentPlant;
    public Action<PlantBehaviour> characterInteractedPlant;
    public Action characterExitPlant;

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.TryGetComponent(out InventoryItem item))
    //     {
    //         inventoryManager.TryAddItem(item.itemName, 1);
    //         Debug.Log(item.itemName + " ");
    //         item.DestroyItem();
    //     }
    // }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.TryGetComponent(out PlantBehaviour plant))                                
        {
            _currentPlant = plant;
            characterInteractedPlant?.Invoke(_currentPlant);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.TryGetComponent(out PlantBehaviour plant) && plant == _currentPlant) 
        {
            _currentPlant = null;
            characterExitPlant?.Invoke();
        }
    }
    
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _currentPlant != null) 
        {
            if (_currentPlant.isHarvestable)
            { 
                inventoryManager.TryAddItem(_currentPlant.itemName, 1); 
                Debug.Log(_currentPlant.itemName + " Added to the Inventory"); 
                _currentPlant.Harvest();
                return;
            }
            _currentPlant.Water();
            characterInteractedPlant?.Invoke(_currentPlant);
            Debug.Log(_currentPlant.itemName + " watered!");
        }
    }
}
