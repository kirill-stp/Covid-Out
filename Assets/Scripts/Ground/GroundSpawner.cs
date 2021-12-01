using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject groundTilePrefab;
    [SerializeField] private SpawnableEnvSO[] RoadObjectSOs;
    [SerializeField] private SpawnableEnvSO[] HouseSOs;
    
    private SpawnableEnvSO[] avaliableRoadObjs;
    private SpawnableEnvSO[] avaliableRoadObjsLeft;
    private SpawnableEnvSO[] avaliableRoadObjsRight;
    
    private SpawnableEnvSO[] avaliableHouses;
    private SpawnableEnvSO[] avaliableHousesLeft;
    private SpawnableEnvSO[] avaliableHousesRight;
    
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
            var RoadObjSO = i < 2 ? ChooseRandomEnvSO(avaliableRoadObjsLeft) : ChooseRandomEnvSO(avaliableRoadObjsRight);
            var RoadObj = Instantiate(RoadObjSO.Prefab);
            RoadObj.transform.position = new Vector3(TempSpawnPos.x, RoadObj.transform.position.y, TempSpawnPos.z);
        }
        
        //Spawn Houses
        //house1
        var houseSpawnPos1 = newTile.transform.GetChild(5).transform;
        var house1 = Instantiate(ChooseRandomEnvSO(avaliableHousesLeft).Prefab);
        house1.transform.position = new Vector3(
            house1.transform.position.x + houseSpawnPos1.position.x,
            house1.transform.position.y,
            houseSpawnPos1.position.z);
        //house2
        var houseSpawnPos2 = newTile.transform.GetChild(6).transform;
        var house2 = Instantiate(ChooseRandomEnvSO(avaliableHousesRight).Prefab);
        //Placement
        house2.transform.position = new Vector3(
            houseSpawnPos2.position.x + house2.transform.position.x,
            house2.transform.position.y,
            houseSpawnPos2.position.z);

    }
    
    private void UpdateAvaliableItems()
    {
        avaliableHouses = GetAvaliableItems(HouseSOs);
        avaliableHousesLeft = GetAvaliableItemsBySide(avaliableHouses, SpawnSide.Left);
        avaliableHousesRight = GetAvaliableItemsBySide(avaliableHouses, SpawnSide.Right);
        
        avaliableRoadObjs = GetAvaliableItems(RoadObjectSOs);
        avaliableRoadObjsLeft = GetAvaliableItemsBySide(avaliableRoadObjs, SpawnSide.Left);
        avaliableRoadObjsRight = GetAvaliableItemsBySide(avaliableRoadObjs, SpawnSide.Right);
    }

    private SpawnableEnvSO ChooseRandomEnvSO(SpawnableEnvSO[] avaliableItems)
    {
        float total = 0;
        foreach (var item in avaliableItems) total += item.SpawnProb;
        
        float randNum = Random.Range(0f, total);
        float sum = 0;
        int chosen = 0;

        for (int i = 0; i < avaliableItems.Length; i++)
        {
            sum += avaliableItems[i].SpawnProb;
            chosen = i;
            if (randNum < sum) break;
        }

        return avaliableItems[chosen];
    }
    
    private SpawnableEnvSO[] GetAvaliableItems(SpawnableEnvSO[] allItems)
    {
        List<SpawnableEnvSO> newItems = new List<SpawnableEnvSO>();
        foreach (var item in allItems)
        {
            if (item.MinLvlState <= LevelStateProvider.LevelState)
            {
                newItems.Add(item);
            }
        }

        return newItems.ToArray();
    }

    private SpawnableEnvSO[] GetAvaliableItemsBySide(SpawnableEnvSO[] allItems, SpawnSide side)
    {
        List<SpawnableEnvSO> itemSide = new List<SpawnableEnvSO>();
        foreach (var item in allItems)
        {
            if (item.SpawnSide == side || item.SpawnSide == SpawnSide.Any)
            {
                itemSide.Add(item);
            }   
        }
        return itemSide.ToArray();
    }
    #endregion

    #region Unity Lifecycle

    void OnEnable()
    {
        GroundTile.OnAnyTileExit += SpawnTile;
        LevelStateProvider.OnLvlStateChanged += UpdateAvaliableItems;
    }

    void Start()
    {
        UpdateAvaliableItems();
        spawnPosition = transform;
        for (int i = 0; i < initialTileCount; i++)
        {
            SpawnTile();
        }
    }

    void OnDisable()
    {
        GroundTile.OnAnyTileExit -= SpawnTile;
        LevelStateProvider.OnLvlStateChanged -= UpdateAvaliableItems;
    }

    #endregion
}
