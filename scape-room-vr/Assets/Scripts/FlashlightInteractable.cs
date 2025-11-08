using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class FlashlightController : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Light spotLight;
    [SerializeField] private XRGrabInteractable grabInteractable;

    [Header("Configuración")]
    [SerializeField] private XRNode controllerNode = XRNode.RightHand;
    [SerializeField] private bool isOn = false;

    [Header("Audio (Opcional)")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clickSound;

    private void Awake()
    {
        // Obtener componentes si no están asignados
        if (spotLight == null)
            spotLight = GetComponentInChildren<Light>();

        if (grabInteractable == null)
            grabInteractable = GetComponent<XRGrabInteractable>();

        // Asegurarse de que la luz empiece apagada
        if (spotLight != null)
            spotLight.enabled = isOn;
    }

    private void OnEnable()
    {
        // Suscribirse a eventos de agarre
        if (grabInteractable != null)
        {
            grabInteractable.activated.AddListener(OnActivate);
        }
    }

    private void OnDisable()
    {
        // Desuscribirse de eventos
        if (grabInteractable != null)
        {
            grabInteractable.activated.RemoveListener(OnActivate);
        }
    }

    // Método llamado cuando se presiona el botón de activación mientras se agarra
    private void OnActivate(ActivateEventArgs args)
    {
        ToggleLight();
    }

    private void ToggleLight()
    {
        isOn = !isOn;

        if (spotLight != null)
        {
            spotLight.enabled = isOn;
        }

        // Reproducir sonido si está configurado
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }

        Debug.Log($"Flashlight {(isOn ? "encendida" : "apagada")}");
    }

    // Método público por si quieres encender/apagar desde otro script
    public void SetLightState(bool state)
    {
        isOn = state;
        if (spotLight != null)
        {
            spotLight.enabled = isOn;
        }
    }
}

