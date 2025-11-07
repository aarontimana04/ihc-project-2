using UnityEngine;
using TMPro;

public class KeypadPanel : MonoBehaviour
{
    public TMP_Text displayText;
    public DoorController door; // Asigna la puerta
    private string currentInput = "";
    private string correctCode = "1234"; // cámbialo por el código que quieras

    public void PressNumber(string number)
    {
        currentInput += number;
        displayText.text = currentInput;
    }

    public void Clear()
    {
        currentInput = "";
        displayText.text = "";
    }

    public void DeleteLast()
    {
        if (currentInput.Length > 0)
        {
            currentInput = currentInput.Substring(0, currentInput.Length - 1);
            displayText.text = currentInput;
        }
    }

    public void Submit()
    {
        if (currentInput == correctCode)
        {
            displayText.text = "Correcto";
            door.OpenDoor();
            gameObject.SetActive(false);
        }
        else
        {
            displayText.text = "Incorrecto";
        }
    }
}
