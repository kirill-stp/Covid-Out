using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

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

    #region Public Methods

    public void SpawnEnemies()
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

    #endregion

    #region Private Methods

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
        GameObject chosenEnemy = new GameObject();

        for (int i = 0; i < EnemyProbs.Length; i++)
        {
            sum += EnemyProbs[i];
            chosenEnemy = EnemyPrefabs[i];
            if (randNum < sum) break;
        }

        return chosenEnemy;
    }

    private void DeleteEnemiesBehind()
    {
        var enemies = FindObjectsOfType<EnemyMovement>();
        foreach (var enemy in enemies)
        {
            if (enemy.transform.position.z - playerTransform.position.z < -5) Destroy(enemy.gameObject);
        }
    }

    #endregion

    #region Unity Lifecycle

    private void OnEnable()
    {
        GroundTile.OnAnyTileExit += DeleteEnemiesBehind;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > spawnDelay)
        {
            currentTime = 0;
            SpawnEnemies();
        }
    }

    private void OnDisable()
    {
        GroundTile.OnAnyTileExit -= DeleteEnemiesBehind;
    }

    #endregion
    
}
