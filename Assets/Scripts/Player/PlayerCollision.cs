using System;
using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static event Action<int> OnPlayerEnemyCollision;
    private bool isImmune = false;
    private IEnumerator currentCoroutine;

    #region Private Methods

    private IEnumerator ImmuneCoroutine(float seconds)
    {
        isImmune = true;
        yield return new WaitForSeconds(seconds);
        isImmune = false;
    }

    #endregion
    
    #region Public Methods

    public void MakeImmune(float seconds)
    {
        if (isImmune) StopCoroutine(currentCoroutine);
        currentCoroutine = ImmuneCoroutine(seconds);
        StartCoroutine(currentCoroutine);
    }

    #endregion

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
