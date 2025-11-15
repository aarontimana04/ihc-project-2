using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [Header("Lista de pedestales del puzzle")]
    public Pedestal[] pedestals;

    [Header("Script que se ejecutará al completar el puzzle")]
    public PuzzleEventHandler eventHandler;

    [Header("Audio al completar el puzzle")]
    public AudioSource audioSource;
    public AudioClip puzzleSolvedClip;

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

        // Reproducir sonido
        if (audioSource != null && puzzleSolvedClip != null)
        {
            audioSource.PlayOneShot(puzzleSolvedClip);
        }
        else
        {
            Debug.LogWarning("Falta AudioSource o AudioClip en PuzzleManager.");
        }

        // Llamamos al manejador del evento (si está asignado)
        if (eventHandler != null)
        {
            eventHandler.OnPuzzleSolved();
        }
        else
        {
            Debug.LogWarning("No hay PuzzleEventHandler asignado en el PuzzleManager.");
        }
    }
}
