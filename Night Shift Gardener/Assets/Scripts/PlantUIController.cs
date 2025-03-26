using UnityEngine;

public class PlantUIController : MonoBehaviour
{
    public GameObject plantUI;

    private void Start()
    {
        plantUI.SetActive(false);
    }

    private void OnMouseEnter()
    {
        plantUI.SetActive(true);
    }

    private void OnMouseExit()
    {
        plantUI.SetActive(false);
    }
}
