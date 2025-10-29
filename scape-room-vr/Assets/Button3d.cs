using UnityEngine;

public class Button3D : MonoBehaviour
{
    public int buttonNumber = 1; // Número del botón (1-9)
    public DoorLockManager doorLockManager;
    public float pressDepth = 0.05f; // Distancia que se "hunde" visualmente
    private Vector3 initialPos;
    private bool pressed = false;

    void Start()
    {
        initialPos = transform.localPosition;
    }

    // Detecta clics con el mouse (solo en modo escena 3D con colisionador)
    private void OnMouseDown()
    {
        Debug.Log($"Botón {buttonNumber} PRESIONADO"); // 

        if (pressed) return;

        pressed = true;
        transform.localPosition = initialPos - new Vector3(0, pressDepth, 0); // efecto de hundir

        // Verificamos que el manager esté asignado
        if (doorLockManager != null)
        {
            doorLockManager.AddInput(buttonNumber);
        }
        else
        {
            Debug.LogWarning("⚠️ doorLockManager no asignado en " + gameObject.name);
        }
    }

    // Permite que el botón vuelva a su posición original
    public void ResetButtonVisual()
    {
        pressed = false;
        transform.localPosition = initialPos;
    }
}
