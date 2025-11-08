using UnityEngine;

public class Pedestal : MonoBehaviour
{
    [Header("Tag que debe tener la piedra correcta")]
    public string requiredTag; // Ej: "PiedraRoja"

    [HideInInspector]
    public bool isCorrect = false;

    private void OnTriggerEnter(Collider other)
    {
        // Si el objeto tiene el tag correcto
        if (other.CompareTag(requiredTag))
        {
            isCorrect = true;
            Debug.Log($"Piedra correcta ({requiredTag}) colocada en {name}");
        }
        else
        {
            isCorrect = false;
            Debug.Log($"Piedra incorrecta ({other.tag}) colocada en {name}");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si se retira la piedra correcta
        if (other.CompareTag(requiredTag))
        {
            isCorrect = false;
            Debug.Log($"Piedra ({requiredTag}) retirada de {name}");
        }
    }
}
