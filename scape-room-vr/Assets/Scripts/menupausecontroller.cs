using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController3 : MonoBehaviour
{
    public GameObject menu; // arrastra aquí tu prefab/objeto de menú

    // Este método será llamado desde el PlayerInput (Invoke Unity Events)
    public void ToggleMenu(InputAction.CallbackContext ctx)
    {
        // Asegurarnos de actuar sólo cuando la acción se haya "performed"
        if (ctx.performed)
        {
            if (menu != null) menu.SetActive(!menu.activeSelf);
        }
    }

    // Alternativa sin contexto (si quieres ligar un método sin parámetros)
    public void ToggleMenuNoCtx()
    {
        if (menu != null) menu.SetActive(!menu.activeSelf);
    }
}