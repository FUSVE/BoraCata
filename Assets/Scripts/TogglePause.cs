using UnityEngine;
using UnityEngine.InputSystem;

public class TogglePause : MonoBehaviour
{
    [SerializeField]
    private Global global; // Referência ao script Global

    private void Awake()
    {
        // Crie uma nova ação de input
        var pauseAction = new InputAction("Pause", InputActionType.Button, "<Keyboard>/escape");

        // Adicione um listener que será chamado quando a ação for acionada
        pauseAction.performed += ToggleIsPaused;

        // Ative a ação
        pauseAction.Enable();
    }

    private void ToggleIsPaused(InputAction.CallbackContext context)
    {
        TogglePauseGame();
    }

    public void TogglePauseButton()
    {
        TogglePauseGame();
    }

    private void TogglePauseGame()
    {
        // Alterna o valor de isPaused quando a tecla Escape é pressionada
        if (global.isPaused)
        {
            global.isPaused = false;
            Time.timeScale = 1f;
            global.uiPause.SetActive(false);
        }
        else
        {
            global.isPaused = true;
            Time.timeScale = 0f;
            if (global.isFinished == false)
            {
                global.uiPause.SetActive(true);
            }
        }
    }
}
