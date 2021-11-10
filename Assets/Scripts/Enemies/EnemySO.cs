using UnityEngine;

[CreateAssetMenu(fileName = "New EnemySO", menuName = "EnemySO")]
public class EnemySO : ScriptableObject
{
    public GameObject Prefab;
    public float SpawnProb;
    public int MinLvlState;
}
