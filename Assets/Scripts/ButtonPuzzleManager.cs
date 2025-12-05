using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ColorImagePair
{
    public string colorName;  // "Red", "Green", "Purple", etc.
    public GameObject imageObject;
}

public class ButtonPuzzleManager : MonoBehaviour
{
    [Header("Panel de fondo")]
    public GameObject blackPanel;  // Panel negro que siempre está visible

    [Header("Colores disponibles")]
    public List<ColorImagePair> colorImages = new List<ColorImagePair>();

    [Header("Config")]
    public int levels = 5;
    public float showDuration = 0.7f;
    public float pauseDuration = 0.3f;

    private string[] sequence;
    private int currentLevel = 1;
    private int currentIndex = 0;
    private bool puzzleCompleted = false;
    private bool inputEnabled = false;

    private Dictionary<string, GameObject> colorImageDict;
    public bool IsCompleted() => puzzleCompleted;

    void Start()
    {
        if (colorImages.Count == 0)
        {
            Debug.LogError("¡LISTA DE COLORES VACÍA! Asigna al menos un color en el Inspector.");
            return;
        }

        // Asegurar que el panel negro esté activo
        if (blackPanel != null)
        {
            blackPanel.SetActive(true);
        }

        colorImageDict = new Dictionary<string, GameObject>();
        foreach (var pair in colorImages)
        {
            if (pair.imageObject == null)
            {
                Debug.LogWarning($"⚠️ El color '{pair.colorName}' no tiene imagen asignada!");
                continue;
            }
            colorImageDict[pair.colorName] = pair.imageObject;
        }

        if (colorImageDict.Count == 0)
        {
            Debug.LogError("¡No hay colores válidos configurados!");
            return;
        }


        // Ocultar todas las imágenes de colores al inicio (solo negro visible)
        HideAllImages();

        GenerateSequence();
        StartCoroutine(ShowSequenceCoroutine());
    }

    void GenerateSequence()
    {
        // Obtener nombres de colores disponibles
        List<string> availableColors = new List<string>(colorImageDict.Keys);

        sequence = new string[levels];
        for (int i = 0; i < levels; i++)
        {
            int randomIndex = Random.Range(0, availableColors.Count);
            sequence[i] = availableColors[randomIndex];
        }

        Debug.Log("🎯 Secuencia generada: " + string.Join(" → ", sequence));
    }

    public void OnButtonPressed(string color)
    {
        if (!inputEnabled || puzzleCompleted)
        {
            Debug.Log($"⛔ Input bloqueado");
            return;
        }

        Debug.Log($"🔘 Presionado: {color} | Esperado: {sequence[currentIndex]} | Progreso: {currentIndex + 1}/{currentLevel}");

        if (color == sequence[currentIndex])
        {
            currentIndex++;

            if (currentIndex >= currentLevel)
            {
                if (currentLevel >= levels)
                {
                    puzzleCompleted = true;
                    StartCoroutine(CelebrationEffect());
                    return;
                }

                Debug.Log($"✅ Nivel {currentLevel} completado → Nivel {currentLevel + 1}");
                currentLevel++;
                currentIndex = 0;
                StartCoroutine(ShowSequenceCoroutine());
            }
        }
        else
        {
            Debug.Log($"ERROR! Reiniciando nivel {currentLevel}");
            currentIndex = 0;
            StartCoroutine(ShowSequenceCoroutine());
        }
    }

    IEnumerator ShowSequenceCoroutine()
    {
        inputEnabled = false;
        HideAllImages();

        yield return new WaitForSeconds(0.5f);

        Debug.Log($"📺 Mostrando secuencia nivel {currentLevel}...");

        for (int i = 0; i < currentLevel; i++)
        {
            string color = sequence[i];
            Debug.Log($"  [{i + 1}/{currentLevel}] Mostrando: {color}");

            // Mostrar el color
            ShowImage(color);
            yield return new WaitForSeconds(showDuration);

            // Ocultar
            HideAllImages();
            yield return new WaitForSeconds(pauseDuration);
        }

        Debug.Log("✋ Input habilitado - ¡Tu turno!");
        inputEnabled = true;
    }

    void ShowImage(string colorName)
    {
        HideAllImages();

        if (colorImageDict.ContainsKey(colorName))
        {
            colorImageDict[colorName].SetActive(true);
        }
        else
        {
            Debug.LogWarning($"⚠️ No se encontró imagen para el color: {colorName}");
        }
    }

    void HideAllImages()
    {
        foreach (var pair in colorImages)
        {
            if (pair.imageObject != null)
            {
                pair.imageObject.SetActive(false);
            }
        }
    }

    IEnumerator CelebrationEffect()
    {
        List<string> availableColors = new List<string>(colorImageDict.Keys);

        for (int i = 0; i < 10; i++)
        {
            string randomColor = availableColors[Random.Range(0, availableColors.Count)];
            ShowImage(randomColor);
            yield return new WaitForSeconds(0.15f);
        }

        // Mostrar todos al final
        foreach (var pair in colorImages)
        {
            if (pair.imageObject != null)
            {
                pair.imageObject.SetActive(true);
            }
        }
    }
}