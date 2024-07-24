using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class SC_PlayerController : MonoBehaviour
{
    static public SC_PlayerController instance;
    public GameObject player;
    private IWeapon _weapon;
    private Mount _mount;
    public SC_PowerController powerController;
    public SC_LifeController lifeController;
    public Transform FirePoint;
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
            SetMount(null);
        }
        if (_weapon != null)
        {
            EquipWeapon(null);
        }
        player.GetComponent<SC_ResetPosition>()?.OnResetPosition();
        lifeController?.LoseLife();
        powerController?.ResetPower();
    }

    public void EquipWeapon(IWeapon weapon)
    {
        if (weapon != null && _mount != null)
        {
            SetMount(null); 
        }
        _weapon = weapon;
    }

    public IWeapon GetWeapon()
    {
        return _weapon;
    }

    public void SetMount(Mount mount)
    {
        if (_mount != null)
        {
            _mount.Dismount();
        }
        if (mount != null && _weapon != null)
        {
            EquipWeapon(null); 
        }
        _mount = mount;
        _mount?.MountUp();
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

    public Transform GetWeaponTransform()
    {
        return FirePoint;
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
