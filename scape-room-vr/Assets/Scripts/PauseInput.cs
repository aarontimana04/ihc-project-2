using UnityEngine;
using UnityEngine.XR;

public class PauseInput : MonoBehaviour
{
    public PauseMenu pauseMenu;

    void Update()
    {
        InputDevice leftHand = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        if (leftHand.TryGetFeatureValue(CommonUsages.primaryButton, out bool pressed) && pressed)
        {
            pauseMenu.TogglePause();
        }
    }
}
