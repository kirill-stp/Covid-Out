using UnityEngine;

public class BuffSpawner : MonoBehaviour
{
    [SerializeField] private PickUpSO[] PickUps;

    #region Private Mentods

    private void Spawn(PickUpSO item)
    {
        Instantiate(item.Prefab, transform.position, Quaternion.identity);
    }

    #endregion

    private void Start()
    {
        float total = 0;
        foreach (var item in PickUps) total += item.SpawnProb;
        
        float randNum = Random.Range(0f, total);
        float sum = 0;
        int chosen = 0;

        for (int i = 0; i < PickUps.Length; i++)
        {
            sum += PickUps[i].SpawnProb;
            chosen = i;
            if (randNum < sum) break;
        }
        
        Spawn(PickUps[chosen]);
        
    }
}
