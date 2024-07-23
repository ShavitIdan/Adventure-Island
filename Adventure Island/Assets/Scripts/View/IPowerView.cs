using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPowerView 
{
    void Initialize(int maxPower);
    void UpdatePowerSlots(float currentPower, int maxPower);
}

