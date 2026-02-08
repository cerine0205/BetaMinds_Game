using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManger : MonoBehaviour
{
    public GameObject pauseManuUI;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            pauseGame();
    }
    public void pauseGame()
    {
        pauseManuUI.SetActive(true);
        Time.timeScale = 0f;

    }

    public void resumeGame()
    {
        pauseManuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void restartGame(string sceneName)
    {
        pauseManuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
