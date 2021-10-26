using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 vectorToTarget;
    
    void Start()
    {
        vectorToTarget = transform.position - target.position;
    }
    
    void FixedUpdate()
    {
        transform.position = target.position + vectorToTarget;
    }
}
