using UnityEngine;

public class ComputerInteraction : MonoBehaviour
{
    [SerializeField] private GameObject pistaUI;

    void Start()
    {
        if (pistaUI) pistaUI.SetActive(false);
    }

    // Llamadas desde los UnityEvents del XR Simple Interactable
    public void ShowPista()
    {
        if (pistaUI) pistaUI.SetActive(true);
    }

    public void HidePista()
    {
        if (pistaUI) pistaUI.SetActive(false);
    }
}
