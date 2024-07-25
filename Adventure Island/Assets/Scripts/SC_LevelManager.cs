using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_LevelManager : MonoBehaviour
{
    public static SC_LevelManager instance;
    public GameObject[] levels; 
    public int currentLevelIndex = 0;
    public Transform[] respawnPoints;
    public CinemachineConfiner2D cinemachineConfiner;
    public Collider2D[] confinerColliders;

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

            if (cinemachineConfiner != null && index < confinerColliders.Length)
            {
                cinemachineConfiner.m_BoundingShape2D = confinerColliders[index];
            }

            // Hide UI screens on level load
            SC_UIManager.instance.HideAllScreens();
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
        SC_UIManager.instance.ShowVictoryScreen();
        SC_PlayerController.instance.getPlayer().gameObject.SetActive(false);
    }

    public void GameOver()
    {
        SC_UIManager.instance.ShowGameOverScreen();
        SC_PlayerController.instance.getPlayer().gameObject.SetActive(false);
    }

    public void PlayerDied()
    {
        SC_PlayerController.instance.OnPlayerDeath();
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        /*SC_PlayerController.instance.lifeController.ResetLives();
        currentLevelIndex = 0;
        LoadLevel(currentLevelIndex);
        SC_PlayerController.instance.getPlayer().gameObject.SetActive(true);
        SC_UIManager.instance.HideAllScreens();*/
    }

    public Vector3 GetCurrentLevelRespawnPoint()
    {
        return respawnPoints[currentLevelIndex].position;
    }
}
