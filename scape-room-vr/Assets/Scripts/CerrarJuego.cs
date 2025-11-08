using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerrarJuego : MonoBehaviour
{
    // Esta función se puede asignar directamente al botón
    public void Salir()
    {
        Debug.Log("Cerrando el juego..."); // útil para probar en el editor

    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif


        Application.Quit(); // Cierra el juego al compilar

        // Nota: Application.Quit() NO cierra el juego en el editor,
        // solo funciona en la versión compilada (EXE, APK, etc.)
    }
}
