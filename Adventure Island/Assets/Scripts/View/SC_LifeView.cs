using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SC_LifeView : MonoBehaviour, ILifeView
{
    public TextMeshProUGUI lifeText;

    public void Initialize(int initialLives)
    {
        UpdateLives(initialLives);
    }

    public void UpdateLives(int lives)
    {
        lifeText.text = "Lives: " + lives;
    }
}
