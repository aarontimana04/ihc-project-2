using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float openAngle = 90f;
    public float speed = 2f;
    private bool opening = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(0, openAngle, 0) * closedRotation;
    }

    public void OpenDoor()
    {
        opening = true;
    }

    void Update()
    {
        if (opening)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, openRotation, Time.deltaTime * speed);
        }
    }
}
