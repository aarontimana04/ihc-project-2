using UnityEngine;
using System.Collections;

public class ScreamerSequence : MonoBehaviour
{
    public Camera vrCamera;       
    public Camera screamerCamera;

    public GameObject gameOverPanel;
    public GameObject screamerObject;
    public AudioSource audioSource;
    public AudioClip screamSound;
    

    void Start()
    {
        screamerCamera.gameObject.SetActive(false);
        screamerObject.SetActive(false);
    }

    public void PlayScreamer()
    {
        StartCoroutine(ScreamerRoutine());
    }

    IEnumerator ScreamerRoutine()
    {
        vrCamera.enabled = false;
        screamerCamera.gameObject.SetActive(true);
        screamerObject.SetActive(true);
        audioSource.PlayOneShot(screamSound);
        yield return new WaitForSeconds(1.2f);
        screamerCamera.gameObject.SetActive(false);
        screamerObject.SetActive(false);
        vrCamera.enabled = true;
        gameOverPanel.SetActive(true);
    }
}
