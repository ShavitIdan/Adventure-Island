using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Weapon : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) )
        {
            SC_PlayerController.instance.GetWeapon()?.Shoot();
            SC_PlayerController.instance.GetMount()?.Attack();
        }
    }

}

