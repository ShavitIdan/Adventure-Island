using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_BoomerangWeapon : MonoBehaviour, IWeapon
{
    public GameObject _boomerangPrefab;
    private GameObject _activeBoomerang;

    public void Shoot()
    {
        if (_boomerangPrefab != null && _activeBoomerang == null)
        {
            _activeBoomerang = Instantiate(_boomerangPrefab, transform.position, Quaternion.identity);
            _activeBoomerang.SetActive(true);

            SC_Boomerang scBoomerang = _activeBoomerang.GetComponent<SC_Boomerang>();
            if (scBoomerang != null)
            {
                float direction = SC_PlayerController.instance.getPlayer().transform.eulerAngles.y == 0 ? 1 : -1;

                SC_PlayerController.instance.GetAnimator().SetTrigger("ThrowTrigger");
                scBoomerang.Shoot(direction);

                scBoomerang.OnBoomerangDeactivate += HandleBoomerangDeactivation;
            }
        }
    }



    private void HandleBoomerangDeactivation()
    {
        if (_activeBoomerang != null)
        {
            SC_Boomerang scBoomerang = _activeBoomerang.GetComponent<SC_Boomerang>();
            if (scBoomerang != null)
            {
                scBoomerang.OnBoomerangDeactivate -= HandleBoomerangDeactivation;
            }
        }

        _activeBoomerang = null;
    }

}
