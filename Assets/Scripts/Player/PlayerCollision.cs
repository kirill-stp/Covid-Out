using System;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static event Action<int> OnPlayerEnemyCollision;
    public static bool isImmune = false;

    #region Unity Lifecycle

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && !isImmune)
        {
            var damage = other.GetComponentInParent<EnemyCollision>().damage;
            OnPlayerEnemyCollision?.Invoke(damage);
        }
    }
    
    #endregion
}
