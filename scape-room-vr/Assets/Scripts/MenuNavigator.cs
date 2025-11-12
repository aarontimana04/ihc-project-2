using UnityEngine;
using Oculus.Interaction;

public class MenuNavigator : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject levelSelectPanel;

    [Header("Buttons")]
    [SerializeField] private PokeInteractable selectLevelButton;
    [SerializeField] private PokeInteractable exitButton;
    [SerializeField] private PokeInteractable backButton; 

    private void Start()
    {
        ShowMainMenu();

        if (selectLevelButton != null)
        {
            selectLevelButton.WhenPointerEventRaised += HandleSelectLevelClick;
        }

        if (exitButton != null)
        {
            exitButton.WhenPointerEventRaised += HandleExitClick;
        }

        if (backButton != null)
        {
            backButton.WhenPointerEventRaised += HandleBackClick;
        }
    }

    private void OnDestroy()
    {
        if (selectLevelButton != null)
        {
            selectLevelButton.WhenPointerEventRaised -= HandleSelectLevelClick;
        }

        if (exitButton != null)
        {
            exitButton.WhenPointerEventRaised -= HandleExitClick;
        }

        if (backButton != null)
        {
            backButton.WhenPointerEventRaised -= HandleBackClick;
        }
    }

    private void HandleSelectLevelClick(PointerEvent evt)
    {
        if (evt.Type == PointerEventType.Select)
        {
            ShowLevelSelect();
        }
    }

    private void HandleExitClick(PointerEvent evt)
    {
        if (evt.Type == PointerEventType.Select)
        {
            ExitGame();
        }
    }

    private void HandleBackClick(PointerEvent evt)
    {
        if (evt.Type == PointerEventType.Select)
        {
            ShowMainMenu();
        }
    }

    public void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
        levelSelectPanel.SetActive(false);
    }

    public void ShowLevelSelect()
    {
        mainMenuPanel.SetActive(false);
        levelSelectPanel.SetActive(true);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}