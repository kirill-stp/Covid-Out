using UnityEngine;
using UnityEngine.UI;

public class ButtonTogglePause : MonoBehaviour
{
    private PauseManager pauseManager;
    private void OnEnable()
    {
        pauseManager = FindObjectOfType<PauseManager>();
        GetComponent<Button>().onClick.AddListener(pauseManager.TogglePause);
    }
}
