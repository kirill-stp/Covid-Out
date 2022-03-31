using UnityEngine;

public class MaskManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private int maxMaskCount;
    [SerializeField] private GameStateManager gameStateManager;
    private int maskCount;
    private UIManager uiManager;

    #endregion

    #region Private Methods

    private void RemoveMasks(int amount)
    {
        maskCount -= amount;
        UpdateMaskScore();
        if (maskCount < 0)
        {
            gameStateManager.EndGame();
            maskCount = 0;
            UpdateMaskScore();
        }
    }

    private void UpdateMaskScore()
    {
        uiManager.SetMaskScore(maskCount);
    }

    #endregion

    #region Public Methods

    public void AddMask(int masksToAdd = 1)
    {
        maskCount += masksToAdd;
        if (maskCount > maxMaskCount) maskCount = maxMaskCount;
        UpdateMaskScore();
    }

    #endregion

    #region Unity lifecycle

    private void OnEnable()
    {
        PlayerCollision.OnPlayerEnemyCollision += RemoveMasks;
    }

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        maskCount = maxMaskCount;
    }

    private void OnDisable()
    {
        PlayerCollision.OnPlayerEnemyCollision -= RemoveMasks;
    }

    #endregion

    
}
