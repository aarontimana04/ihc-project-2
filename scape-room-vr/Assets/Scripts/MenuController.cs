using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainPanel;   // Panel del menú principal
    public GameObject helpPanel;   // Panel de ayuda

    [Header("Nombre de escena del juego (debe estar en Build Settings)")]
    public string gameSceneName = "Scene/ScapeRoomScene"; // <- cámbialo si aplica

    void Start() => ShowMain();

    public void StartGame()
    {
        if (!IsSceneInBuild(gameSceneName))
        {
            Debug.LogError($"[Menu] La escena '{gameSceneName}' NO está en Build Settings. " +
                           "Abre File → Build Settings y añádela.");
            return;
        }

        Debug.Log($"[Menu] Cargando escena '{gameSceneName}'…");
        SceneManager.LoadScene(gameSceneName, LoadSceneMode.Single);
    }

    public void ShowHelp()
    {
        if (mainPanel) mainPanel.SetActive(false);
        if (helpPanel) helpPanel.SetActive(true);
    }

    public void ShowMain()
    {
        if (helpPanel) helpPanel.SetActive(false);
        if (mainPanel) mainPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    private bool IsSceneInBuild(string sceneName)
    {
        int count = SceneManager.sceneCountInBuildSettings;
        for (int i = 0; i < count; i++)
        {
            var path = SceneUtility.GetScenePathByBuildIndex(i);
            var name = System.IO.Path.GetFileNameWithoutExtension(path);
            if (name == sceneName) return true;
        }
        return false;
    }
}
