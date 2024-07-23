using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PlayerController : MonoBehaviour
{
    static public SC_PlayerController instance;
    public GameObject player;
    public SC_PowerController powerController;
    public SC_LifeController lifeController;
    private Animator anim;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        anim = player.GetComponent<Animator>();
    }

    private void OnEnable()
    {
        if (powerController != null)
        {
            powerController.OnPowerGone += OnPlayerDeath;
        }
    }

    private void OnDisable()
    {
        if (powerController != null)
        {
            powerController.OnPowerGone -= OnPlayerDeath;
        }
    }

    private void OnPlayerDeath()
    {
        player.GetComponent<SC_ResetPosition>()?.OnResetPosition();
        lifeController?.LoseLife();
        powerController?.ResetPower();
    }

    public void ChangePower(float amount)
    {
        powerController.ChangePower(amount);
    }
    public Animator GetAnimator()
    {
        return anim;
    }

    public void kill()
    {
        OnPlayerDeath();
    }
}
