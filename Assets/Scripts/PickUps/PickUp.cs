using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private GameObject pickupParticlePrefab;

    #region Private Methods

    protected virtual void PickUpEffect(GameObject player)
    {
        
    }

    #endregion

    #region Unity lifecycle
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Settings.Tags.Player))
        {
            PickUpEffect(other.gameObject);
            var particles = Instantiate(pickupParticlePrefab, transform.position, Quaternion.identity);
            Destroy(particles,1f);
            Destroy(gameObject);
        }
    }

    #endregion
}
