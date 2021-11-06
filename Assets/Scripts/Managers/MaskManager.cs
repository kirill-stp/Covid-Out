using UnityEngine;

public class MaskManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private int maxMaskCount;
    private int maskCount;
    private UIManager uiManager;

    #endregion

    #region Private Methods

    private void UpdateMaskScore()
    {
        uiManager.SetMaskScore(maskCount);
    }

    private void RemoveMasks(int amount)
    {
        maskCount -= amount;
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
