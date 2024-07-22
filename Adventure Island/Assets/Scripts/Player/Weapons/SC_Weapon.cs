using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Weapon : MonoBehaviour
{
    public SC_AxeWeapon _axeWeapon;
    public SC_BoomerangWeapon _boomerangWeapon;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && _axeWeapon != null)
        {
            _axeWeapon.Shoot();
        }
        if (Input.GetKeyDown(KeyCode.Z) && _boomerangWeapon != null)
        {

            _boomerangWeapon.Shoot();

        }
    }

}

