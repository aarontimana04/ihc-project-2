using UnityEngine;
using TMPro;

public class DialClock : MonoBehaviour
{
    public enum DialAxis { X, Y, Z }

    [Header("Visual")]
    [SerializeField] private TextMeshProUGUI clockDisplay;

    [Header("Puzzle")]
    [SerializeField] private DialAxis axis = DialAxis.Y;
    [SerializeField] private int targetValue = 4;
    [SerializeField] private float angleStep = 30f;

    public int CurrentValue { get; private set; }

    void Update()
    {
        Vector3 e = transform.localEulerAngles;

        float angle = 0f;
        switch (axis)
        {
            case DialAxis.X: angle = e.x; break;
            case DialAxis.Y: angle = e.y; break;
            case DialAxis.Z: angle = e.z; break;
        }

        // Normalizar a 0–360
        angle = Mathf.Repeat(angle, 360f);

        // Convertir a valor discreto
        CurrentValue = Mathf.RoundToInt(angle / angleStep);

        // Si quieres que solo vaya de 0 a 9, por ejemplo:
        CurrentValue = CurrentValue % 10;

        if (clockDisplay != null)
            clockDisplay.text = CurrentValue.ToString("00") + ":00";
    }

    public bool IsCorrect()
    {
        return CurrentValue == targetValue;
    }
}
