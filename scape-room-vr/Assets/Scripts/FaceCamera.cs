using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    private Transform cam;
    [SerializeField] private float distanceFromCamera = 200.0f;

    void Start()
    {
        cam = Camera.main.transform;
    }

    void OnEnable()
    {
        if (cam == null) cam = Camera.main.transform;

        transform.position = cam.position + cam.forward * distanceFromCamera;
        transform.LookAt(cam);
        transform.Rotate(0, 180f, 0);
    }

    void LateUpdate()
    {
        transform.position = cam.position + cam.forward * distanceFromCamera;
        transform.LookAt(cam);
        transform.Rotate(0, 180f, 0);
    }
}