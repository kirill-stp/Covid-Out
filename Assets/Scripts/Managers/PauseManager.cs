using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private UIManager uiManager;
    private bool isPaused;

    public void TogglePause(bool isUi = false)
    {
        if (isPaused)
        {
            ResumeGame(isUi);
        }
        else
        {
            PauseGame(isUi);
        }

        isPaused = !isPaused;
    }
    
    private void PauseGame(bool isUi = false)
    {
        Time.timeScale = 0f;
        if (isUi) uiManager.CreatePauseView();
    }

    private void ResumeGame(bool isUi = false)
    {
        Time.timeScale = 1f;
        if (isUi) uiManager.DeletePauseView();
    }

    #region Unity lifecycle

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    #endregion
    
}
