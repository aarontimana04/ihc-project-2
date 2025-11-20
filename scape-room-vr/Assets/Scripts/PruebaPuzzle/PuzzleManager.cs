using UnityEngine;

public class PuzzleManager2 : MonoBehaviour
{
    public static PuzzleManager2 instance;

    public SphereSlot[] slots;   // Arrastra aquí los 3 sockets
    public int[] correctOrder;   // Ej: [5, 2, 9] si esas son las correctas

    private void Awake()
    {
        instance = this;
    }

    public void CheckSolution()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].currentSphere == null)
                return; // Si falta una esfera, no evalúa

            if (slots[i].currentSphere.number != correctOrder[i])
                return; // Incorrecto → no hacer nada
        }

        // Si pasó TODO → puzzle resuelto
        Debug.Log(" ¡Puzzle resuelto! ");
        PuzzleSolved();
    }

    private void PuzzleSolved()
    {
        // Aquí abres la puerta, activas el Escape Room, etc.
        Debug.Log("Ejecutar acción final.");
    }
}
