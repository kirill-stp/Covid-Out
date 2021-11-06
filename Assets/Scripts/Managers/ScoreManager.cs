using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Transform playerTransform;
    
    void Update()
    {
        scoreText.text = playerTransform.position.z.ToString("0");
    }
}
