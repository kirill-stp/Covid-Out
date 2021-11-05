using System;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    public static event Action OnAnyTileExit;

    private void OnTriggerExit (Collider other)
    {
        if (other.CompareTag(Settings.Tags.Player))
        {
            OnAnyTileExit?.Invoke();
            Destroy(gameObject, 1f);
        }
    }
}
