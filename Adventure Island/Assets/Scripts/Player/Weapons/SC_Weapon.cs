using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Weapon : MonoBehaviour
{
    public SC_AxeWeapon axeWeapon;
    public SC_BoomerangWeapon boomerangWeapon;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) )
        {
            SC_PlayerController.instance.GetWeapon()?.Shoot();
            SC_PlayerController.instance.GetMount()?.Attack();
        }
    }

    public void EquipAxe()
    {
        SC_PlayerController.instance.EquipWeapon(axeWeapon);
    }

    public void EquipBoomerang()
    {
        SC_PlayerController.instance.EquipWeapon(boomerangWeapon);
    }



}

