using System;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject gameOverView;
    [SerializeField] private SceneLoaderSO sceneLoader;
    [SerializeField] private PauseManager pauseManager;
    
    
    
    private static bool IsGameEnded;

    #endregion

    #region Events

    public static event Action OnGameEnded;

    #endregion

    #region Public Methods

    public void EndGame()
    {
        if (IsGameEnded) return;
        gameOverView.gameObject.SetActive(true);
        pauseManager.TogglePause();
        IsGameEnded = true;
        OnGameEnded?.Invoke();
    }

    public void UndoEndGame()
    {
        if (!IsGameEnded) return;
        IsGameEnded = false;
        pauseManager.TogglePause();
        gameOverView.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        IsGameEnded = false;
        pauseManager.TogglePause();
        sceneLoader.RestartCurrentScene();
    }

    public void ExitLevel()
    {
        IsGameEnded = false;
        pauseManager.TogglePause();
        sceneLoader.LoadStartScene();
    }

    #endregion

    #region Private Methods
    
    private void Start()
    {
        IsGameEnded = false;
    }

    #endregion
}
