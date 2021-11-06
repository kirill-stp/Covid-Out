using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private UIManager uiManager;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    void Update()
    {
        uiManager.SetScore(playerTransform.position.z);
    }
    
}
