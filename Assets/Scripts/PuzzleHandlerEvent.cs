using UnityEngine;

public class PuzzleEventHandler : MonoBehaviour
{
    [SerializeField] private GameObject GameOverPanel;
    public void OnPuzzleSolved()
    {
        Debug.Log("Evento del puzzle resuelto ejecutado.");
        /*
        if (objetoADesactivar != null)
        {
            objetoADesactivar.SetActive(false);
            Debug.Log($"Objeto '{objetoADesactivar.name}' desactivado.");
        }
        else
        {
            Debug.LogWarning("No se ha asignado ningún objeto a desactivar en PuzzleEventHandler.");
        }**/
        //door.position = openTransform.position;
        GameOverPanel.SetActive(false);
    }
}