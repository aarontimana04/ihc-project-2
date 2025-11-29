using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController4 : MonoBehaviour
{
    public GameObject menu;
    public CountdownClock countdown;

    private void Start()
    {
        menu.SetActive(false);
        enabled = false; 
    }

    public void ToggleMenu(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;

        bool show = !menu.activeSelf;
        menu.SetActive(show);

        if (countdown != null)
        {
            if (show)
                countdown.StopCountdown();
            else
                countdown.StartCountdown();
        }
    }

    // Llamar desde el botón Play
    public void EnablePauseSystem()
    {
        enabled = true; // Activar el script
    }
}