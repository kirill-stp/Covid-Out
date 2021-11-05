using System;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static event Action OnPlayerEnemyCollision;

    #region Unity Lifecycle

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            OnPlayerEnemyCollision?.Invoke();
        }
    }

    #endregion
}
