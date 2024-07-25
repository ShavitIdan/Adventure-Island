using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_AxeWeapon : MonoBehaviour, IWeapon
{
    public GameObject _axe;

    public SC_AxeWeapon(GameObject axePrefab)
    {
        _axe = axePrefab;
    }
    public void Shoot()
    {
        if (_axe != null)
        {
            GameObject axe = SC_AxePool.sharedInstance.GetPooledAxe();
            axe.transform.position = transform.position;
            axe.SetActive(true);

            SC_Axe scAxe = axe.GetComponent<SC_Axe>();
            if (scAxe != null)
            {
                float direction = SC_PlayerController.instance.getPlayer().transform.eulerAngles.y == 0 ? 1 : -1;

                SC_PlayerController.instance.GetAnimator().SetTrigger("ThrowTrigger");
                scAxe.Shoot(direction);
            }
        }
    }



}
