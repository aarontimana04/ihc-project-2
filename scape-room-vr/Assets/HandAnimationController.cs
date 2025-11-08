using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimationController : MonoBehaviour
{
    [Header("Input Actions (desde XR Controller)")]
    public InputActionProperty gripAction;
    public InputActionProperty triggerAction;

    [Header("Animator de la Mano")]
    public Animator handAnimator;

    void Update()
    {
        // Leer los valores del grip y del trigger
        float gripValue = gripAction.action.ReadValue<float>();
        float triggerValue = triggerAction.action.ReadValue<float>();

        // Pasar esos valores al Animator
        handAnimator.SetFloat("Grip", gripValue);
        handAnimator.SetFloat("Trigger", triggerValue);
    }
}
