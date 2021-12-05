using UnityEngine;

[CreateAssetMenu(fileName = "New SpawnableEnvSO",menuName = "SpawnableEnvSO")]
public class SpawnableEnvSO : ScriptableObject
{
    public GameObject Prefab;
    public int[] LvlStates;
    public float SpawnProb;
    public SpawnSide SpawnSide;
}

public enum SpawnSide
{
    Any = 0,
    Left,
    Right
}