using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI maskScoreText;
    [SerializeField] private Canvas pauseViewPrefab;
    [SerializeField] private Canvas gameOverViewPrefab;
    [SerializeField] private Timer timer;
    

    private Canvas pauseView;
    public Canvas gameOverView;
    
    #endregion

    #region Public Methods

    public void StartTimer(float time)
    {
        timer.startTimer(time);
    }

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

    public void CreateGameOverView()
    {
        gameOverView = Instantiate(gameOverViewPrefab);
    }

    public void DeleteGameOverView()
    {
        Destroy(gameOverView.gameObject);
    }

    #endregion
}