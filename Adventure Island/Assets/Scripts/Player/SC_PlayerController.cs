using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class SC_PlayerController : MonoBehaviour
{
    static public SC_PlayerController instance;
    public GameObject player;
    private IWeapon weapon;
    private Mount _mount;
    public SC_PowerController powerController;
    public SC_LifeController lifeController;
    private Animator anim;

    private bool isImmune = false;

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
        if (_mount != null)
        {
            _mount.Dismount();
            _mount = null;
        }
        if (weapon != null)
        {
            EquipWeapon(null);
        }
        player.GetComponent<SC_ResetPosition>()?.OnResetPosition();
        lifeController?.LoseLife();
        powerController?.ResetPower();
    }

    public void EquipWeapon(IWeapon weapon)
    {
        this.weapon = weapon;
    }

    public IWeapon GetWeapon()
    {
        return weapon;
    }

    public void SetMount(Mount mount)
    {
        if (_mount != null)
        {
            _mount.Dismount();
            _mount = null;
        }
        if (mount != null)
        {
            mount.MountUp();
            _mount = mount;
        }
        
    }

    public Mount GetMount()
    {
        return _mount;
    }
    public void SetImmune(bool value)
    {
        isImmune = value;
    }

    public bool GetImmune()
    {
        return isImmune;
    }
    public void ChangePower(float amount)
    {
        powerController.ChangePower(amount);
    }
    public Animator GetAnimator()
    {
        return anim;
    }

    public GameObject getPlayer()
    {
        return player;
    }

    public void kill()
    {
        if (_mount != null)
        {
            _mount.Dismount();
            _mount = null;
        }
        else
            OnPlayerDeath();
    }
}
