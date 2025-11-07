using System.Collections;
using UnityEngine;
using TMPro;

public class CountdownClock : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private int startMinutes = 10;
    [SerializeField] private bool startOnAwake = true;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip tickSound;

    private float remaining;
    private bool running;
    private int lastSecond; 

    void Awake()
    {
        remaining = startMinutes * 60f;
        lastSecond = Mathf.FloorToInt(remaining); 
        if (label) label.text = Format(remaining);
        if (GameOverPanel) GameOverPanel.SetActive(false);
    }

    void Start()
    {
        if (startOnAwake)
        {
            StartCoroutine(IniciarCronometro());
        }
    }

    IEnumerator IniciarCronometro()
    {
        yield return null;
        running = true;
    }

    public void StartCountdown()
    {
        StartCoroutine(IniciarCronometro());
    }

    public void StopCountdown()
    {
        running = false;
    }

    void Update()
    {
        if (!running) return;

        remaining -= Time.deltaTime;

        int currentSecond = Mathf.FloorToInt(remaining);
        if (currentSecond != lastSecond && remaining > 0)
        {
            lastSecond = currentSecond;

            if (audioSource && tickSound)
            {
                audioSource.PlayOneShot(tickSound);
            }
        }

        if (remaining <= 0f)
        {
            remaining = 0f;
            running = false;
            if (GameOverPanel)
            {
                GameOverPanel.SetActive(true);
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