using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_BoomerangWeapon : MonoBehaviour, IWeapon
{
    public GameObject _boomerangPrefab;
    private GameObject _activeBoomerang;
    private bool _isEquip = true;

    public void Shoot()
    {
        if (_isEquip && _boomerangPrefab != null && _activeBoomerang == null)
        {
            _activeBoomerang = Instantiate(_boomerangPrefab, transform.position, Quaternion.identity);
            _activeBoomerang.SetActive(true);

            SC_Boomerang scBoomerang = _activeBoomerang.GetComponent<SC_Boomerang>();
            if (scBoomerang != null)
            {
                float direction = 1;
                if (transform.parent != null)
                    direction = transform.parent.localScale.x;
                SC_PlayerController.instance.GetAnimator().SetTrigger("ThrowTrigger");
                scBoomerang.Shoot(direction);

                scBoomerang.OnBoomerangDeactivate += HandleBoomerangDeactivation;
            }
        }
    }


    private void HandleBoomerangDeactivation()
    {
        // Unsubscribe from the event to avoid potential memory leaks
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

    public void Equip()
    {
        _isEquip = true;
    }

    public void UnEquip()
    {
        _isEquip = false;
    }
}
