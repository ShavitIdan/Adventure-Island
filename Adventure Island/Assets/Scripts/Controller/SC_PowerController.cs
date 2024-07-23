using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PowerController : MonoBehaviour
{

    public MonoBehaviour viewBehaviour;
    private IPowerView view;
    private IPowerModel model;

    public int maxPower = 15;
    public float decreaseAmount = 1f;
    public float decreaseTime = 2f;

    public event Action OnPowerGone;

    private void Awake()
    {
        view = viewBehaviour as IPowerView;
        if (view == null)
        {
            Debug.LogError("View does not implement IPowerView interface");
        }
    }

    private void Start()
    {
        model = new PowerModel(maxPower, decreaseAmount, decreaseTime) as IPowerModel;
        if (model == null)
        {
            Debug.LogError("Model does not implement IPowerModel interface");
        }

        if (view != null)
        {
            view.Initialize(maxPower);
            UpdateView();
            StartCoroutine(model.DecreasePowerOverTime(UpdateView, OnPlayerDeath));
        }
        else
        {
            Debug.LogError("View is not initialized properly");
        }
    }

    private void UpdateView()
    {
        if (view != null)
        {
            view.UpdatePowerSlots(model.CurrentPower, model.MaxPower);
        }
    }

    public void ChangePower(float amount)
    {
        model.ChangePower(amount);
        UpdateView();
    }

    public void ResetPower()
    {
        model.ResetPower();
        UpdateView();
        StopAllCoroutines();
        StartCoroutine(model.DecreasePowerOverTime(UpdateView, OnPlayerDeath));
    }

        private void OnPlayerDeath()
    {
        Debug.Log("Player is dead");
        OnPowerGone?.Invoke();
    }
}
