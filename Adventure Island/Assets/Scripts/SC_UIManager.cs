using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SC_UIManager : MonoBehaviour
{
    public static SC_UIManager instance;
    public GameObject victoryScreen;
    public GameObject gameOverScreen;
    public Button victoryRestartButton;
    public Button gameOverRestartButton;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Add listeners to the restart buttons
        victoryRestartButton.onClick.AddListener(RestartGame);
        gameOverRestartButton.onClick.AddListener(RestartGame);
    }

    public void ShowVictoryScreen()
    {
        victoryScreen.SetActive(true);
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    public void HideAllScreens()
    {
        victoryScreen.SetActive(false);
        gameOverScreen.SetActive(false);
    }

    public void RestartGame()
    {
        SC_LevelManager.instance.ResetGame();
    }
}
