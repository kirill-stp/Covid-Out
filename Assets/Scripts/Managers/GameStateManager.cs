using System;
using UnityEngine;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{
    #region Variables

    private static UIManager uiManager;
    private static PauseManager pauseManager;
    
    private static bool IsGameEnded;

    #endregion

    #region Events

    public static event Action OnGameEnded;

    #endregion

    #region Public Methods

    public static void EndGame()
    {
        if (IsGameEnded) return;
        pauseManager.TogglePause();
        IsGameEnded = true;
        uiManager.CreateGameOverView();
        uiManager.gameOverView.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(ResumeGame);
        OnGameEnded?.Invoke();
    }

    public static void ResumeGame()
    {
        if (!IsGameEnded) return;
        pauseManager.TogglePause();
        IsGameEnded = false;
        uiManager.DeleteGameOverView();
    }

    #endregion

    #region Private Methods

    private void OnEnable()
    {
        OnGameEnded += EndGame;
    }

    private void Start()
    {
        IsGameEnded = false;
        uiManager = FindObjectOfType<UIManager>();
        pauseManager = FindObjectOfType<PauseManager>();
    }

    private void OnDisable()
    {
        OnGameEnded -= EndGame;
    }

    #endregion
}
