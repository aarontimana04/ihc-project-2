using UnityEngine;
using TMPro;

public class KeypadDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text displayText;
    [SerializeField] private string correctCode = "1234";
    [SerializeField] private DoorController door;

    private string currentInput = "";

    public void AddDigit(string digit)
    {
        currentInput += digit;
        displayText.text = currentInput;
    }

    public void ClearInput()
    {
        currentInput = "";
        displayText.text = "";
    }

    public void ConfirmInput()
    {
        if (currentInput == correctCode)
        {
            Debug.Log("Código correcto, abriendo puerta...");
            door.OpenDoor();
        }
        else
        {
            Debug.Log("Código incorrecto");
        }

        // limpia la pantalla después de confirmar
        currentInput = "";
        displayText.text = "";
    }
}
