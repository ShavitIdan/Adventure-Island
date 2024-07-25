using UnityEngine;

public class SC_LifeController : MonoBehaviour
{
    public MonoBehaviour viewBehaviour;
    private ILifeView view;
    private ILifeModel model;

    public int initialLives = 3;

    private void Awake()
    {
        view = viewBehaviour as ILifeView;
        if (view == null)
        {
            Debug.LogError("View does not implement ILifeView interface");
        }
    }

    private void Start()
    {
        model = new LifeModel(initialLives);
        model.OnLifeChanged += UpdateView;
        model.OnPlayerDeath += HandlePlayerDeath;

        if (view != null)
        {
            view.Initialize(model.Lives);
        }
    }

    private void UpdateView()
    {
        view?.UpdateLives(model.Lives);
    }

    private void HandlePlayerDeath()
    {
        Debug.Log("Player has died and has no more lives");
    }

    public void LoseLife()
    {
        model.LoseLife();
    }

    public void GainLife()
    {
        model.GainLife();
    }

    public int GetLives()
    {
        return model.Lives;
    }
}
