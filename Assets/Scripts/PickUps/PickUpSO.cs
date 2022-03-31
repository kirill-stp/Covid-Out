using UnityEngine;

[CreateAssetMenu(menuName = "PickUpSO")]
public class PickUpSO : ScriptableObject
{
    public GameObject Prefab;
    public int[] LvlStates;
    public float SpawnProb;
}
