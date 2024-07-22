using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAxeBuilder
{
    void SetSpeed();
    void SetLifeTime();

    GameObject Build(GameObject fireballPrefab);
}
