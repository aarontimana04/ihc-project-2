using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoorLockManager : MonoBehaviour
{
    [Header("Configuración")]
    public string correctCode = "123"; // cambiar desde Inspector
    public Transform door; // arrastra el objeto Puerta aquí
    public float openAngle = 90f;
    public float openSpeed = 6f;

    private string currentCode = "";
    private bool isOpen = false;
    private Quaternion closedRot;
    private Quaternion targetRot;

    void Start()
    {
        if (door != null)
            closedRot = door.localRotation;
    }

    public void AddInput(int number)
    {
        if (isOpen) return;

        currentCode += number.ToString();
        Debug.Log("Input actual: " + currentCode);

        if (currentCode.Length == 3)
        {
            if (currentCode == correctCode)
            {
                StartCoroutine(OpenDoorRoutine());
            }
            else
            {
                Debug.Log("Código incorrecto");
                StartCoroutine(ResetAfterDelay(0.5f));
            }
        }
    }

    IEnumerator OpenDoorRoutine()
    {
        isOpen = true;
        // calculamos rotación objetivo: rotar local en Y
        targetRot = closedRot * Quaternion.Euler(0, openAngle, 0);

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * openSpeed;
            door.localRotation = Quaternion.Slerp(door.localRotation, targetRot, t);
            yield return null;
        }
        door.localRotation = targetRot;
        Debug.Log("Puerta abierta!");
    }

    IEnumerator ResetAfterDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        currentCode = "";
        // opcional: resetear visual de botones
        Button3D[] botones = GetComponentsInChildren<Button3D>();
        foreach (Button3D b in botones) b.ResetButtonVisual();
    }
}
