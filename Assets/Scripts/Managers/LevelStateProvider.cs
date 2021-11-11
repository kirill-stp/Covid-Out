using System;
using UnityEngine;

public class LevelStateProvider : MonoBehaviour
{

    #region Variables

    [SerializeField] private Transform playerTransform;

    private int lvlStateBuff;
    
    public static int LevelState { get; private set; }
    public static float ZSpeedChange { get; private set; }
    public static float EnemySpawnProb { get; private set; }
    public static float EnemySpawnDelay { get; private set; }

    #endregion

    #region Events

    public static event Action OnLvlStateChanged;

    #endregion

    #region Private Methods

    private int GetLvlState()
    {
        var wayPoints = Settings.GameConstants.ScoreWayPoints;
        var newLvlState = 0;
        for (int i = 0; i < wayPoints.Length; i++)
        {
            if (playerTransform.position.z > wayPoints[i])
            {
                newLvlState = i+1;
            }
        }

        return newLvlState;
    }

    private void UpdateState()
    {
        ZSpeedChange = Settings.GameConstants.ZSpeedChanges[LevelState];
        EnemySpawnProb = Settings.GameConstants.EnemySpawnProbs[LevelState];
        UpdateEnemySpawnDelay();
    }

    private void UpdateEnemySpawnDelay()
    {
        if (LevelState == Settings.GameConstants.EnemySpawnDelays.Length - 1)
        {
            if (EnemySpawnDelay > Settings.GameConstants.EnemySpawnDelayCap)
            {
                EnemySpawnDelay -= Settings.GameConstants.EnemySpawnDelayChange;
            }
        }
        else
        {
            EnemySpawnDelay = Settings.GameConstants.EnemySpawnDelays[LevelState];
        }
    }

    #endregion
    
    #region Unity Lifecycle

    private void Awake()
    {
        LevelState = lvlStateBuff = 0;
        UpdateState();
    }

    private void Update()
    {
        LevelState = GetLvlState();
        if (LevelState != lvlStateBuff)
        {
            lvlStateBuff = LevelState;
            UpdateState();
            OnLvlStateChanged?.Invoke();
        }

        if (LevelState == Settings.GameConstants.ScoreWayPoints.Length)
        {
            UpdateEnemySpawnDelay();
        }
    }

    #endregion
}
