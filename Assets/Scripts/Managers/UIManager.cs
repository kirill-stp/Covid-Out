using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI maskScoreText;
    [SerializeField] private Canvas pauseViewPrefab;

    private Canvas pauseView;
    
    #endregion

    #region Public Methods

    public void SetScore(float scoreValue)
    {
        scoreText.text = scoreValue.ToString("0");
    }

    public void SetMaskScore(int maskScoreValue)
    {
        maskScoreText.text = maskScoreValue.ToString();
    }

    public void CreatePauseView()
    {
        pauseView = Instantiate(pauseViewPrefab);
    }

    public void DeletePauseView()
    {
        Destroy(pauseView.gameObject);
    }

    #endregion
}
