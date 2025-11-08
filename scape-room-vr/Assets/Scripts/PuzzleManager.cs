using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [Header("Lista de pedestales del puzzle")]
    public Pedestal[] pedestals;

    [Header("Script que se ejecutará al completar el puzzle")]
    public PuzzleEventHandler eventHandler; // Este será un objeto de tipo PuzzleEventHandler

    private bool puzzleCompleted = false;

    void Update()
    {
        if (!puzzleCompleted)
        {
            CheckPuzzle();
        }
    }

    void CheckPuzzle()
    {
        foreach (Pedestal pedestal in pedestals)
        {
            if (!pedestal.isCorrect)
                return; // Si alguno está mal, el puzzle no está completo
        }

        puzzleCompleted = true;
        OnPuzzleSolved();
    }

    void OnPuzzleSolved()
    {
        Debug.Log("¡Puzzle completado correctamente!");

        // Llamamos al manejador del evento (si está asignado)
        if (eventHandler != null)
        {
            eventHandler.OnPuzzleSolved(); // Aquí se llama al otro script
        }
        else
        {
            Debug.LogWarning("No hay PuzzleEventHandler asignado en el PuzzleManager.");
        }
    }
}
