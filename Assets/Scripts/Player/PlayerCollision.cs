using System;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static event Action<int> OnPlayerEnemyCollision;

    #region Unity Lifecycle

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var damage = other.GetComponentInParent<EnemyCollision>().damage;
            OnPlayerEnemyCollision?.Invoke(damage);
        }
    }
    
    #endregion
}
