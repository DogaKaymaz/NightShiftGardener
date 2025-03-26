using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public string itemName;
    public void DestroyItem()
    {
        Destroy(this.gameObject);
    }
}
