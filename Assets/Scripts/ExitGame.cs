using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void Salir()
    {
        Debug.Log("Cerrando el juego..."); 

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
