using UnityEngine;
using TMPro;

public class CountdownClock : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private int startMinutes = 10;
    [SerializeField] private bool startOnAwake = false;
    [SerializeField] private GameObject GameOverPanel;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip startSound;       // Este sonido hará loop

    private float remaining;
    private bool running;

    void Awake()
    {
        remaining = startMinutes * 60f;
        if (label) label.text = Format(remaining);

        if (startOnAwake) StartCountdown();

        if (GameOverPanel) GameOverPanel.SetActive(false);
    }

    public void StartCountdown()
    {
        running = true;

        // 🔊 Reproducir sonido en loop
        if (audioSource && startSound)
        {
            audioSource.clip = startSound;
            audioSource.loop = true;   // 🔁 Activar loop
            audioSource.Play();        // ▶ Comenzar la música
        }
    }

    public void StopCountdown()
    {
        running = false;

        // Detener el audio si lo deseas
        if (audioSource)
            audioSource.Stop();
    }

    void Update()
    {
        if (!running) return;

        remaining -= Time.deltaTime;

        if (remaining <= 0f)
        {
            remaining = 0f;
            running = false;

            // Cuando termina, también puedes detener el sonido:
            if (audioSource)
                audioSource.Stop();

            FindObjectOfType<LightController>()?.TurnOffAllLights();
            FindObjectOfType<ScreamerSequence>()?.PlayScreamer();
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
