using System;
using UnityEngine;

public class LifeModel : ILifeModel
{
    private int lives;
    public int Lives => lives;

    int ILifeModel.Lives { get => lives; set { lives = value; OnLifeChanged?.Invoke();} }

    public event Action OnLifeChanged;
    public event Action OnPlayerDeath;

    public LifeModel(int initialLives)
    {
        lives = initialLives;
    }

    public void LoseLife()
    {
        lives--;
        OnLifeChanged?.Invoke();
        if (lives <= 0)
        {
            OnPlayerDeath?.Invoke();
        }
    }

    public void GainLife()
    {
        lives++;
        OnLifeChanged?.Invoke();
    }
}
