using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_AxeWeapon : MonoBehaviour, IWeapon
{
    public GameObject _axe;
    private bool _isEquip = true;

    public void Shoot()
    {
        if (_isEquip && _axe != null)
        {
            GameObject axe = SC_AxePool.sharedInstance.GetPooledAxe();
            axe.transform.position = transform.position;
            axe.SetActive(true);

            SC_Axe scAxe = axe.GetComponent<SC_Axe>();
            if (scAxe != null)
            {
                float direction = 1;
                if (transform.parent != null)
                    direction = transform.parent.localScale.x;
                SC_PlayerController.instance.GetAnimator().SetTrigger("ThrowTrigger");
                scAxe.Shoot(direction);
            }
        }
    }

    public void Equip()
    {
        _isEquip = true;
    }

    public void UnEquip()
    {
        _isEquip = false;
    }
}
