using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerModel : IPowerModel
{
    public int MaxPower { get; private set; }
    public float CurrentPower { get; private set; }
    public float decreaseAmount;
    public float decreaseTime;

    public PowerModel(int maxPower, float decreaseAmount, float decreaseTime)
    {
        MaxPower = maxPower;
        this.decreaseAmount = decreaseAmount;
        this.decreaseTime = decreaseTime;
        CurrentPower = maxPower;
    }

    public void ChangePower(float amount)
    {
        CurrentPower += amount;
        CurrentPower = Mathf.Clamp(CurrentPower, 0, MaxPower);
    }

    public IEnumerator DecreasePowerOverTime(Action onPowerChanged, Action onPlayerDeath)
    {
        while (CurrentPower > 0)
        {
            yield return new WaitForSeconds(decreaseTime);
            ChangePower(-decreaseAmount);
            onPowerChanged?.Invoke();

            if (CurrentPower <= 0)
            {
                onPlayerDeath?.Invoke();
            }
        }
    }

    public void ResetPower()
    {
        CurrentPower = MaxPower;
    }
}
