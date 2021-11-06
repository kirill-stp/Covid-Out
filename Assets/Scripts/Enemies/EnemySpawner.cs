using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    #region Variables
    
    [Header("Enemy prefabs with spawn probability")]
    [SerializeField] private GameObject[] EnemyPrefabs;
    [SerializeField] private float[] EnemyProbs;
    [Space]
    [SerializeField] private Transform playerTransform;
    [Space]
    [SerializeField] private float spawnDelay;

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
                bool isSpawn = Random.Range(0f, 1f) < Settings.GameConstants.EnemySpawnProbability;
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
        float total = EnemyProbs.Sum();
        
        float randNum = Random.Range(0f, total);
        float sum = 0;
        int chosen = 0;

        for (int i = 0; i < EnemyProbs.Length; i++)
        {
            sum += EnemyProbs[i];
            chosen = i;
            if (randNum < sum) break;
        }

        return EnemyPrefabs[chosen];
    }
    
    #endregion

    #region Unity Lifecycle

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > spawnDelay)
        {
            currentTime = 0;
            SpawnEnemies();
        }
    }

    #endregion
    
}
