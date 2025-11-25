using UnityEngine;

public class ScreamerTrigger : MonoBehaviour
{
    public Animator anim;
    public string screamerTriggerName = "Screamer";

    public AudioSource audioSrc;
    public AudioClip screamSound;

    public Transform playerCamera;
    public float distanceFromCamera = 0.3f;
    public float heightOffset = -0.1f;

    public float hideDelay = 1.2f; 

    public void TriggerScreamer()
    {
        if (playerCamera != null)
        {
            Vector3 pos = playerCamera.position + playerCamera.forward * distanceFromCamera;
            pos.y += heightOffset;
            transform.position = pos;
            transform.LookAt(playerCamera);
        }

        if (anim != null)
            anim.SetTrigger(screamerTriggerName);

        if (audioSrc != null && screamSound != null)
            audioSrc.PlayOneShot(screamSound);

    }
}
