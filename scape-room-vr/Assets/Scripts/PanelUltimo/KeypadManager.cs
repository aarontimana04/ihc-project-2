using UnityEngine;

public class KeypadManager : MonoBehaviour
{
    public string correctCode = "1234";
    private string currentInput = "";

    public DoorController door;

    public void PressKey(string key)
    {
        Debug.Log("Tecla presionada: " + key);

        if (key == "C")
        {
            currentInput = "";
            return;
        }

        if (key == "OK")
        {
            if (currentInput == correctCode)
            {
                Debug.Log("Código correcto");
                door.OpenDoor();
            }
            else
            {
                Debug.Log("Código incorrecto");
            }

            currentInput = "";
            return;
        }

        // Si es un número normal
        currentInput += key;
    }
}
