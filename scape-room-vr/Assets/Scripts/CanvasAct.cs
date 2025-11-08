using UnityEngine;

public class PanelActivator : MonoBehaviour
{
    public GameObject canvasToShow;  // Asigna aquí tu Canvas (CanvasKeypad)
    private bool isCanvasActive = false;

    void Start()
    {
        if (canvasToShow != null)
        {
            canvasToShow.SetActive(false); // Asegura que inicie apagado
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("? El jugador ha entrado en el área del panel.");
            ToggleCanvas(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("?? El jugador ha salido del área del panel.");
            ToggleCanvas(false);
        }
    }

    // Si quieres que el panel también reaccione a clics (por ejemplo, con el mouse o raycast)
    private void OnMouseDown()
    {
        Debug.Log("??? El panel fue clickeado.");
        ToggleCanvas(!isCanvasActive);
    }

    private void ToggleCanvas(bool state)
    {
        if (canvasToShow != null)
        {
            canvasToShow.SetActive(state);
            isCanvasActive = state;
            Debug.Log(state ? "?? Canvas ACTIVADO." : "? Canvas DESACTIVADO.");
        }
        else
        {
            Debug.LogWarning("?? No se asignó ningún Canvas en el Inspector.");
        }
    }
}
