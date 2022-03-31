using UnityEngine;

public class MaskPickUp : MonoBehaviour
{
    [SerializeField] private GameObject pickupParticlePrefab;
    [SerializeField] private int maskAmount;

    #region Unity lifecycle
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Settings.Tags.Player))
        {
            FindObjectOfType<MaskManager>().AddMask(maskAmount);
            var particles = Instantiate(pickupParticlePrefab, transform.position, Quaternion.identity);
            Destroy(particles,1f);
            Destroy(gameObject);
        }
    }

    #endregion
}
