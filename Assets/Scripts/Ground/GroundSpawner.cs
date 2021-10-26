using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject groundTilePrefab;
    [SerializeField] private int initialTileCount;
    
    private Transform spawnPosition;

    #endregion

    #region Public Methods

    public void SpawnTile()
    {
        var newTile = Instantiate(groundTilePrefab, spawnPosition.position, Quaternion.identity);
        spawnPosition = newTile.transform.GetChild(1).transform;
    }

    #endregion

    #region Unity Lifecycle

    void OnEnable()
    {
        GroundTile.OnAnyTileExit += SpawnTile;
    }

    void Start()
    {
        spawnPosition = transform;
        for (int i = 0; i < initialTileCount; i++)
        {
            SpawnTile();
        }
    }

    void OnDisable()
    {
        GroundTile.OnAnyTileExit -= SpawnTile;
    }

    #endregion
}
