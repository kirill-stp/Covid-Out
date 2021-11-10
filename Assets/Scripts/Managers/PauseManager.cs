using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private UIManager uiManager;
    private bool isPaused;

    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }

        isPaused = !isPaused;
    }
    
    private void PauseGame()
    {
        Time.timeScale = 0f;
        uiManager.CreatePauseView();
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
        uiManager.DeletePauseView();
    }

    #region Unity lifecycle

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    #endregion
    
}
