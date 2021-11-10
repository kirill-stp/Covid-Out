using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    #region Variables
    
    [Header("Enemy prefabs with spawn probability")]
    [SerializeField] private EnemySO[] EnemySOs;
    [Space]
    [SerializeField] private Transform playerTransform;
    
    private EnemySO[] avaliableEnemies;
    private float currentTime;

    #endregion

    #region Private Methods

    private void SpawnEnemies()
    {
        int reservedLine = Random.Range(-1, 2);
        for (int i = -1; i < 2; i++)
        {
            if (i != reservedLine)
            {
                bool isSpawn = Random.Range(0f, 1f) < LevelStateProvider.EnemySpawnProb;
                if (isSpawn) SpawnEnemyOnLine(i);
            }
        }
    }

    private void SpawnEnemyOnLine(int lane)
    {
        var enemyPrefab = ChoseEnemy();
        var spawnPosition = new Vector3(lane * Settings.GameConstants.PlayerSlideDistance,
            playerTransform.position.y,
            playerTransform.position.z + Settings.GameConstants.PlayerEnemyDistance);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    private GameObject ChoseEnemy()
    {
        float total = 0;
        foreach (var enemy in avaliableEnemies) total += enemy.SpawnProb;

        float randNum = Random.Range(0f, total);
        float sum = 0;
        int chosen = 0;

        for (int i = 0; i < avaliableEnemies.Length; i++)
        {
            sum += avaliableEnemies[i].SpawnProb;
            chosen = i;
            if (randNum < sum) break;
        }

        return avaliableEnemies[chosen].Prefab;
    }

    private void UpdateAvaliableEnemies()
    {
        List<EnemySO> newEnemies = new List<EnemySO>();
        foreach (var enemy in EnemySOs)
        {
            if (enemy.MinLvlState <= LevelStateProvider.LevelState)
            {
                newEnemies.Add(enemy);
            }
        }

        avaliableEnemies = newEnemies.ToArray();
    }
    
    #endregion

    #region Unity Lifecycle

    private void OnEnable()
    {
        LevelStateProvider.OnLvlStateChanged += UpdateAvaliableEnemies;
    }

    private void Awake()
    {
        UpdateAvaliableEnemies();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > LevelStateProvider.EnemySpawnDelay)
        {
            currentTime = 0;
            SpawnEnemies();
        }
    }

    private void OnDisable()
    {
        LevelStateProvider.OnLvlStateChanged -= UpdateAvaliableEnemies;
    }

    #endregion
    
}
