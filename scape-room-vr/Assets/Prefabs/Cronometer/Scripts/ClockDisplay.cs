using UnityEngine;
using TMPro;

public class CountdownClock : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private int startMinutes = 10;
    [SerializeField] private bool startOnAwake = true;
    [SerializeField] private GameObject GameOverPanel;

    private float remaining;
    private bool running;

    void Awake()
    {
        remaining = startMinutes * 60f;
        if (label) label.text = Format(remaining);
        if (startOnAwake) StartCountdown();

        if (GameOverPanel) GameOverPanel.SetActive(false); // ocultar al inicio
    }

    public void StartCountdown() { running = true; }
    public void StopCountdown() { running = false; }

    void Update()
    {
        if (!running) return;
        remaining -= Time.deltaTime;

        if (remaining <= 0f)
        {
            remaining = 0f;
            running = false;
            if (GameOverPanel)
            {
                GameOverPanel.SetActive(true); // muestra el panel cuando termina
            }
        }

        if (label) label.text = Format(remaining);
    }

    string Format(float s)
    {
        int m = Mathf.FloorToInt(s / 60f);
        int sec = Mathf.FloorToInt(s % 60f);
        return $"{m:00}:{sec:00}";
    }
}
