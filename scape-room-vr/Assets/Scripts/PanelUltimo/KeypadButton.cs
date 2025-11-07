using UnityEngine;

public class KeypadButton : MonoBehaviour
{
    public string value;              // “1”, “2”, “3”, “C", “OK”
    public KeypadDisplay display;     // referencia al display

    public void Press()
    {
        // Botón borrar
        if (value == "C")
        {
            display.ClearInput();
            return;
        }

        // Botón confirmar
        if (value == "OK")
        {
            display.ConfirmInput();
            return;
        }

        // Botón numérico
        display.AddDigit(value);
    }
}
