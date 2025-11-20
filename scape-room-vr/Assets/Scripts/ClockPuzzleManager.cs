using UnityEngine;

public class ClockPuzzleManager : MonoBehaviour
{
    public DialClock dialA;
    public DialClock dialB;
    public DialClock dialC;

    [Header("Resultado del puzzle")]
    public GameObject codePanel;   // Panel con el código
    public AudioSource successSound; // opcional

    private bool solved;

    void Start()
    {
        if (codePanel != null)
            codePanel.SetActive(false); // aseguramos que arranca oculto
    }

    void Update()
    {
        if (solved) return;

        if (dialA.IsCorrect() && dialB.IsCorrect() && dialC.IsCorrect())
        {
            solved = true;
            Debug.Log("Puzzle de relojes resuelto");

            if (codePanel != null)
                codePanel.SetActive(true);  // 🔥 mostrar panel

            if (successSound != null)
                successSound.Play();        // sonido opcional
        }
    }
}
