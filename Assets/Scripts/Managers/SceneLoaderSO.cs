using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "SceneLoaderSO", fileName = "new SceneLoaderSO")]
public class SceneLoaderSO : ScriptableObject
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
