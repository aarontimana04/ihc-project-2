using UnityEngine;

public class ColorButton : MonoBehaviour
{
    public string colorName;  // Asignado en el inspector: "Red", "Green", etc.
    public ButtonPuzzleManager manager;

    public void Press()
    {
        manager.OnButtonPressed(colorName);
    }
}
