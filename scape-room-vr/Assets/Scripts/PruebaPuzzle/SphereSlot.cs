using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SphereSlot : MonoBehaviour
{
    public int correctNumber;  // Número correcto que debe ir aquí
    public PuzzleSphere currentSphere;

    private void Start()
    {
        var socket = GetComponent<XRSocketInteractor>();
        socket.selectEntered.AddListener(OnSpherePlaced);
        socket.selectExited.AddListener(OnSphereRemoved);
    }

    private void OnSpherePlaced(SelectEnterEventArgs args)
    {
        currentSphere = args.interactableObject.transform.GetComponent<PuzzleSphere>();
        PuzzleManager2.instance.CheckSolution();
    }

    private void OnSphereRemoved(SelectExitEventArgs args)
    {
        currentSphere = null;
    }
}
