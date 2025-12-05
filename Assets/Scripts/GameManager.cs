using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Lista de puzzles del juego")]
    public PuzzleManager[] puzzles;

    [Header("UI de victoria")]
    public GameObject winPanel;

    [Header("Cronómetro")]
    public CountdownClock time;

    private bool winGame = false;

    void Update()
    {
        CheckWinCondition();
    }

    void CheckWinCondition()
    {
        if (winGame)
        {
            return;
        }

        foreach (PuzzleManager puzzle in puzzles)
        {
            if (!puzzle.IsCompleted())
            {
                return; // si uno no está completo, salimos
            }
        }

        winGame = true;
        ShowWinPanel();
    }

    void ShowWinPanel()
    {
        time.StopCountdown();
        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }

        Debug.Log("GANASTE EL JUEGO!");
    }
}
