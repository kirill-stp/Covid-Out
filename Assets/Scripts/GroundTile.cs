using System;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    public static event Action OnAnyTileExit;

    private void OnTriggerExit (Collider other)
    {
        OnAnyTileExit?.Invoke();
        print("exit");
        Destroy(gameObject, 1f);
    }
}
