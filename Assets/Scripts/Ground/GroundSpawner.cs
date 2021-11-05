using UnityEngine;
using UnityEngine.UIElements;

public class GroundSpawner : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject groundTilePrefab;
    [SerializeField] private GameObject[] RoadObjPrefabs;
    [SerializeField] private GameObject[] HousePrefabs;
    
    [SerializeField] private int initialTileCount;
    [SerializeField] private float RoadObjSpawnChance;
    
    private Transform spawnPosition;

    #endregion

    #region Private Methods

    private void SpawnTile()
    {
        //SpawnGround
        var newTile = Instantiate(groundTilePrefab, spawnPosition.position, Quaternion.identity);
        spawnPosition = newTile.transform.GetChild(0).transform;

        //Spawn Road Objects
        for (int i = 0; i < 4; i++)
        {
            if (Random.Range(0f, 1f) > RoadObjSpawnChance) continue;
            var TempSpawnPos = newTile.transform.GetChild(1 + i).transform.position;
            var RoadObj = Instantiate(ChooseRandomRoadObj());
            RoadObj.transform.position = new Vector3(TempSpawnPos.x, RoadObj.transform.position.y, TempSpawnPos.z);
        }
        
        //Spawn Houses
        //house1
        var houseSpawnPos1 = newTile.transform.GetChild(5).transform;
        var house1 = Instantiate(ChooseRandomHouse());
        house1.transform.position = new Vector3(
            house1.transform.position.x + houseSpawnPos1.position.x,
            house1.transform.position.y,
            houseSpawnPos1.position.z);
        //house2
        var houseSpawnPos2 = newTile.transform.GetChild(6).transform;
        var house2 = Instantiate(ChooseRandomHouse());
        //Turning around
        house2.transform.Rotate(0f,180f,0f);
        //Placement
        house2.transform.position = new Vector3(
            houseSpawnPos2.position.x - house2.transform.position.x,
            house2.transform.position.y,
            houseSpawnPos2.position.z);

    }

    private GameObject ChooseRandomRoadObj()
    {
        var index = Random.Range(0, RoadObjPrefabs.Length);
        return RoadObjPrefabs[index];
    }

    private GameObject ChooseRandomHouse()
    {
        var index = Random.Range(0, HousePrefabs.Length);
        return HousePrefabs[index];
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
