using UnityEngine;

public class BalanceManager : MonoBehaviour
{
    [Header("Configuración de la balanza")]
    public float leftMass = 10f; // Masa fija del lado izquierdo
    public float tolerance = 0.5f; // Tolerancia para considerar equilibrada

    [Header("Zonas de la balanza")]
    public Transform leftZone;  // Zona izquierda (donde detectar objetos)
    public Transform rightZone; // Zona derecha (donde detectar objetos)

    [Header("Script que se ejecutará al equilibrar")]
    public PuzzleEventHandler eventHandler;

    [Header("Audio al equilibrar")]
    public AudioSource audioSource;
    public AudioClip balancedClip;

    private bool isBalanced = false;
    private float currentRightMass = 0f;

    // Propiedad pública para verificación externa
    public bool IsBalanced => isBalanced;

    void Update()
    {
        if (!isBalanced)
        {
            CheckBalance();
        }
    }

    void CheckBalance()
    {
        // Calcular masa del lado derecho
        currentRightMass = CalculateMassInZone(rightZone);

        // Verificar si está equilibrada
        float difference = Mathf.Abs(leftMass - currentRightMass);

        if (difference <= tolerance)
        {
            isBalanced = true;
            OnBalanceSolved();
        }
    }

    float CalculateMassInZone(Transform zone)
    {
        float totalMass = 0f;

        // Buscar todos los objetos con Rigidbody en la zona
        Collider[] colliders = Physics.OverlapBox(
            zone.position,
            zone.localScale / 2f,
            zone.rotation
        );

        foreach (Collider col in colliders)
        {
            Rigidbody rb = col.GetComponent<Rigidbody>();
            if (rb != null && col.CompareTag("BalanceObject")) // Tag para objetos pesables
            {
                totalMass += rb.mass;
            }
        }

        return totalMass;
    }

    void OnBalanceSolved()
    {
        Debug.Log("¡Balanza equilibrada correctamente!");

        // Reproducir sonido
        if (audioSource != null && balancedClip != null)
        {
            audioSource.PlayOneShot(balancedClip);
        }

        // Notificar al event handler
        if (eventHandler != null)
        {
            eventHandler.OnPuzzleSolved();
        }
    }

    // Para visualizar las zonas en el editor
    void OnDrawGizmos()
    {
        if (leftZone != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(leftZone.position, leftZone.localScale);
        }

        if (rightZone != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(rightZone.position, rightZone.localScale);
        }
    }
}