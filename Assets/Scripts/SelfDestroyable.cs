using UnityEngine;

public class SelfDestroyable : MonoBehaviour
{
    private GameObject player;
    private void SelfDestroy()
    {
        if (transform.position.z < player.transform.position.z) Destroy(gameObject, 1f);
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(Settings.Tags.Player);
    }

    private void OnEnable()
    {
        GroundTile.OnAnyTileExit += SelfDestroy;
    }

    private void OnDisable()
    {
        GroundTile.OnAnyTileExit -= SelfDestroy;
    }
}
