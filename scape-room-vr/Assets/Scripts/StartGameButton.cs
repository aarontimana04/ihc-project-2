using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    [SerializeField] private CountdownClock clock;

    public void OnStartButtonClick()
    {
        if (clock)
            clock.StartCountdown();
    }
}