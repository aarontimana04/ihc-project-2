using UnityEngine;
using System.Collections;

public class Pedestal : MonoBehaviour
{
    [Header("Tag que debe tener la piedra correcta")]
    public string requiredTag; // Ej: "PiedraRoja"

    [HideInInspector]
    public bool isCorrect = false;

    private Coroutine delayCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        // Si el objeto tiene el tag correcto
        if (other.CompareTag(requiredTag))
        {
            // Iniciar corrutina para activar isCorrect luego de 2 segundos
            delayCoroutine = StartCoroutine(SetCorrectAfterDelay(2f));
            Debug.Log($"Piedra correcta ({requiredTag}) detectada en {name}, esperando 2 segundos...");
        }
        else
        {
            isCorrect = false;
            Debug.Log($"Piedra incorrecta ({other.tag}) colocada en {name}");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si la piedra correcta se retira antes de que pasen los 2 segundos
        if (other.CompareTag(requiredTag))
        {
            if (delayCoroutine != null)
            {
                StopCoroutine(delayCoroutine);
                delayCoroutine = null;
            }

            isCorrect = false;
            Debug.Log($"Piedra ({requiredTag}) retirada de {name} antes de completarse el tiempo.");
        }
    }

    private IEnumerator SetCorrectAfterDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        isCorrect = true;
        Debug.Log($"Piedra correcta ({requiredTag}) colocada correctamente en {name} después de {seconds} segundos.");
    }
}
