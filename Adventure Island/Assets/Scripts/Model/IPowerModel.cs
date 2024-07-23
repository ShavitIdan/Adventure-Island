using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPowerModel 
{
    float CurrentPower { get; }
    int MaxPower { get; }
    IEnumerator DecreasePowerOverTime(Action onPowerChanged, Action onPlayerDeath);
    void ChangePower(float amount);
    void ResetPower();
}
