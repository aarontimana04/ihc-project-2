using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Referencias")]
    public PuzzleManager puzzleManager;

    [Header("UI de victoria")]
    public GameObject winPanel;

    [Header("Cronómetro")]
    public CountdownClock Cronometer;   // Si tienes un script Timer, si no dime cómo lo manejas.

    private bool winShown = false;

    void Update()
    {
        CheckWinCondition();
    }

    void CheckWinCondition()
    {
        if (!winShown && puzzleManager != null && puzzleManager.IsCompleted())
        {
            winShown = true;
            ShowWinPanel();
        }
    }

    void ShowWinPanel()
    {
        if (winPanel != null)
            winPanel.SetActive(true);

        if (Cronometer != null)
            Cronometer.StopCountdown();

        Debug.Log("Victoria: panel activado y timer detenido.");
    }
}
