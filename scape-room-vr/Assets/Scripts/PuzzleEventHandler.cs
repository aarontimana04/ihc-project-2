using UnityEngine;

public class PuzzleEventHandler : MonoBehaviour
{
    //[Header("Objeto a desactivar al resolver el puzzle")]
    //public GameObject objetoADesactivar;

    public Transform door;
    public Transform openTransform;
    [SerializeField] private GameObject GameOverPanel;

    // Este método es llamado por el PuzzleManager al resolver el puzzle
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
        door.position = openTransform.position;
        GameOverPanel.SetActive(true);
    }
}
