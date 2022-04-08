using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject timerUI;
    [SerializeField] private RectTransform TimerBarImage;
    
    private float startTime;
    private float currentTime;

    private float width;

    #region Public Methods

    public void startTimer(float time)
    {
        startTime = currentTime = time;
        timerUI.SetActive(true);
    }

    #endregion

    #region private methods

    private void UpdateUI()
    {
        var newWidth = (currentTime / startTime) * width;
        TimerBarImage.sizeDelta = new Vector2(newWidth, TimerBarImage.rect.height);
    }

    #endregion
    
    #region Unity Lifecycle

    private void Start()
    {
        width = TimerBarImage.rect.width;
    }

    private void Update()
    {
        if (!timerUI.activeSelf) return;
        
        currentTime -= Time.deltaTime;
        if (currentTime <= 0) timerUI.SetActive(false);
        else
        {
            UpdateUI();
        }
    }

    #endregion
}
