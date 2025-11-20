using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    public bool isPaused = false;

    public void TogglePause()
    {
        isPaused = !isPaused;

        pauseCanvas.SetActive(isPaused);

        if (isPaused)
        {
            Time.timeScale = 0f;   // Pausa el juego
        }
        else
        {
            Time.timeScale = 1f;   // Reanuda
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
    }

}
