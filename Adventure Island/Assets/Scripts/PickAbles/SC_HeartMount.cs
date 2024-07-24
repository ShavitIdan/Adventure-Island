using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_HeartMount : MonoBehaviour, IPickAble
{
    public GameObject mountPrefab;

    public void OnPickUp(GameObject picker)
    {
        if (mountPrefab != null)
        {
            GameObject mountObject = Instantiate(mountPrefab, picker.transform.position, Quaternion.identity);
            mountObject.transform.SetParent(picker.transform);
            Mount mount = mountObject.GetComponent<Mount>();
            if (mount != null)
            {
                SC_PlayerController.instance.SetMount(mount);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnPickUp(collision.gameObject);
        }
    }

}
