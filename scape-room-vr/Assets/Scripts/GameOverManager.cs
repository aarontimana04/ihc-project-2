using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Transform xrOrigin;

    private Vector3 posicionInicial;
    private Quaternion rotacionInicial;

    void Start()
    {
        if (xrOrigin)
        {
            posicionInicial = xrOrigin.position;
            rotacionInicial = xrOrigin.rotation;
        }
    }

    public void ReiniciarEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReiniciarPosicion()
    {
        if (xrOrigin)
        {
            xrOrigin.position = posicionInicial;
            xrOrigin.rotation = rotacionInicial;
        }

        gameOverPanel.SetActive(false);

        FindObjectOfType<CountdownClock>().StartCountdown();
    }
}