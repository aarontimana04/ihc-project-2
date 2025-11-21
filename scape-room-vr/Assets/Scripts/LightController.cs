using UnityEngine;

public class LightController : MonoBehaviour
{
    private Light[] allLights;

    void Start()
    {
        allLights = FindObjectsOfType<Light>();
    }

    public void TurnOffAllLights()
    {
        foreach (Light l in allLights)
        {
            l.enabled = false;
        }
    }
}
