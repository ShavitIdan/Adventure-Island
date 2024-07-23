using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface ILifeModel
{
    int Lives { get; }
    void LoseLife();
    void GainLife();
    event Action OnLifeChanged;
    event Action OnPlayerDeath;
}
