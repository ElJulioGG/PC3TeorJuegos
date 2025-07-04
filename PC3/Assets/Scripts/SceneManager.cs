using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private bool isPaused = false;

    public void scenePlay()
    {
        SceneManager.LoadScene("PlayEscena");
    }
    public void sceneMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1f;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0f;
            isPaused = true;
        }
    }

    public void ReloadScene()
    {
        GameManager.instance.playerHealth = 1;
        GameManager.instance.playerTime = 0f;
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
