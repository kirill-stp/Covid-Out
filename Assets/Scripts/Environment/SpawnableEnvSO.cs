using UnityEngine;

[CreateAssetMenu(fileName = "New SpawnableEnvSO",menuName = "SpawnableEnvSO")]
public class SpawnableEnvSO : ScriptableObject
{
    public GameObject Prefab;
    public int MinLvlState;
    public float SpawnProb;
    //public SpawnSide SpawnSide;
}
/*
public enum SpawnSide
{
    Left,
    Right
}*/