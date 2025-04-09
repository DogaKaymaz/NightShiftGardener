using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public InventoryItem inventoryItem;
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        originalPosition = rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null)
        {
            PlantingSpot spot = hit.collider.GetComponent<PlantingSpot>();
            if (spot != null)
            {
                // if (inventoryItem.itemData is PlantData plantData)
                // {
                //     spot.PlantSeed(plantData, inventoryItem.itemQualityData);
                //     GameManager.mcInventoryManager.TrySpend(inventoryItem, 1);
                // }
                if (inventoryItem.itemData is SeedData seedData)
                {
                    spot.PlantSeed(seedData.plantData, inventoryItem.itemQualityData);
                    GameManager.mcInventoryManager.TrySpend(inventoryItem, 1);
                }
            }
            rectTransform.anchoredPosition = originalPosition;
        }
    }
}
