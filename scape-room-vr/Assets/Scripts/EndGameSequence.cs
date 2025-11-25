using UnityEngine;
using System.Collections;

public class EndGameSequence : MonoBehaviour
{
    public Light[] lightsToTurnOff;   
    public ScreamerTrigger screamer;    
    public GameObject gameOverPanel;   
    public float delayBeforeScreamer = 2f;
    public float delayBeforeGameOver = 2f;

    public void StartEndSequence()
    {
        StartCoroutine(EndSequenceRoutine());
    }

    private IEnumerator EndSequenceRoutine()
    {
        foreach (var l in lightsToTurnOff)
            l.enabled = false;

        yield return new WaitForSeconds(delayBeforeScreamer);

        if (screamer != null)
            screamer.TriggerScreamer();

        yield return new WaitForSeconds(delayBeforeGameOver);

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }
}
