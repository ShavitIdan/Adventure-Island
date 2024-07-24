using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_AxePickable : MonoBehaviour, IPickAble
{

    public void OnPickUp(GameObject picker)
    {
        SC_Weapon weaponController = picker.GetComponentInChildren<SC_Weapon>();
        if (weaponController != null)
        {
            weaponController.EquipAxe();
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnPickUp(collision.gameObject);
            Destroy(gameObject); 
        }
    }
}
