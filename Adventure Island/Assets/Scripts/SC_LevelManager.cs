using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_LevelManager : MonoBehaviour
{
    public static SC_LevelManager instance;
    public GameObject[] levels; // Array of levels
    public int currentLevelIndex = 0;
    public Transform[] respawnPoints;
    public GameObject victoryScreen;
    public GameObject gameOverScreen;
    private int playerLives;
/*
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        playerLives = SC_PlayerController.instance.lifeController.GetLives();
        LoadLevel(currentLevelIndex);
    }

    public void LoadLevel(int index)
    {
        if (index < levels.Length)
        {
            for (int i = 0; i < levels.Length; i++)
            {
                levels[i].SetActive(i == index);
            }
            currentLevelIndex = index;
            SC_PlayerController.instance.Respawn(respawnPoints[index].position);
        }
    }

    public void NextLevel()
    {
        if (currentLevelIndex + 1 < levels.Length)
        {
            LoadLevel(currentLevelIndex + 1);
        }
        else
        {
            Victory();
        }
    }

    public void Victory()
    {
        victoryScreen.SetActive(true);
        playerController.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        playerController.gameObject.SetActive(false);
    }

    public void PlayerDied()
    {
        playerLives--;
        if (playerLives > 0)
        {
            playerController.Respawn(respawnPoints[currentLevelIndex].position);
        }
        else
        {
            GameOver();
        }
    }

    public void ResetGame()
    {
        playerLives = playerController.lifeController.GetLives();
        currentLevelIndex = 0;
        LoadLevel(currentLevelIndex);
        playerController.gameObject.SetActive(true);
        gameOverScreen.SetActive(false);
        victoryScreen.SetActive(false);
    }
*/
}

