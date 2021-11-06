using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public int damage;
    [SerializeField] private GameObject collisionParticlePrefab;
    

    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<TraumaInducer>().StartPlayShake();
        var particles = Instantiate(collisionParticlePrefab, transform.position, Quaternion.identity);
        Destroy(particles,1f);
        Destroy(gameObject);
    }
}
