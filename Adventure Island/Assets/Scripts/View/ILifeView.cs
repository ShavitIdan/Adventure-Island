using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILifeView
{
    void Initialize(int initialLives);
    void UpdateLives(int lives);
}
