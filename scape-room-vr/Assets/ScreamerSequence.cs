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
        screamerCamera.enabled = false; 
        screamerObject.SetActive(false);
    }


    public void PlayScreamer()
    {
        StartCoroutine(ScreamerRoutine());
    }

    IEnumerator ScreamerRoutine()
    {
        vrCamera.gameObject.SetActive(false);
        screamerCamera.gameObject.SetActive(true);
        screamerObject.SetActive(true);
        audioSource.PlayOneShot(screamSound);
        yield return new WaitForSeconds(3f);
        vrCamera.gameObject.SetActive(true);
        screamerCamera.gameObject.SetActive(false);
        screamerObject.SetActive(false);
        vrCamera.gameObject.SetActive(true);
        gameOverPanel.SetActive(true);
    }
}

/*
 
 using UnityEngine;
using System.Collections;

public class ScreamerSequence : MonoBehaviour
{
    public Transform ovrCameraRig;        // El OVRCameraRig completo o TrackingSpace
    public Transform screamerPosition;     // Transform vacío en la posición donde quieres el screamer
    public GameObject gameOverPanel;
    public GameObject screamerObject;
    public AudioSource audioSource;
    public AudioClip screamSound;

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Start()
    {
        screamerObject.SetActive(false);

        // Guarda la posición original
        if (ovrCameraRig != null)
        {
            originalPosition = ovrCameraRig.position;
            originalRotation = ovrCameraRig.rotation;
        }
    }

    public void PlayScreamer()
    {
        StartCoroutine(ScreamerRoutine());
    }

    IEnumerator ScreamerRoutine()
    {
        // Teletransporta el rig completo a la posición del screamer
        ovrCameraRig.position = screamerPosition.position;
        ovrCameraRig.rotation = screamerPosition.rotation;

        screamerObject.SetActive(true);
        audioSource.PlayOneShot(screamSound);

        yield return new WaitForSeconds(3f);

        // Regresa el rig a su posición original
        ovrCameraRig.position = originalPosition;
        ovrCameraRig.rotation = originalRotation;

        screamerObject.SetActive(false);
        gameOverPanel.SetActive(true);
    }
}*/ 