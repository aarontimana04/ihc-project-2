using UnityEngine;

using UnityEngine.XR;

public class FlashlightInteractable : MonoBehaviour
{
    private Light flashlight;
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    private bool wasPressed = false;

    void Start()
    {
        flashlight = GetComponentInChildren<Light>();
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

        if (flashlight != null)
        {
            flashlight.enabled = false;
        }
    }

    void Update()
    {
        // Verificar si está agarrada
        if (grabInteractable != null && grabInteractable.isSelected)
        {
            // Buscar cualquier controlador derecho
            InputDevice rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

            // Leer botón primario
            bool pressed;
            if (rightHand.TryGetFeatureValue(CommonUsages.primaryButton, out pressed))
            {
                if (pressed && !wasPressed)
                {
                    flashlight.enabled = !flashlight.enabled;
                }
                wasPressed = pressed;
            }
        }
    }
}