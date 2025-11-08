using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    // Cambia a cualquier escena cuyo nombre se pase como parámetro
    [Header("Nombre exacto de la escena (debe estar en Build Settings)")]
    public string nombreEscena;

    public void CargarEscena(string nombreEscena)
    {
        if (!string.IsNullOrEmpty(nombreEscena))
        {
            SceneManager.LoadScene(nombreEscena);
        }
        else
        {
            Debug.LogWarning("No se ha especificado un nombre de escena.");
        }
    }
}
