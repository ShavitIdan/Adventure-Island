using System.Collections;
using System.Collections.Generic;
using UnityEditor.Sprites;
using UnityEngine;

public class SC_Fruit : MonoBehaviour, IPickAble
{
    public int powerValue = 3;

    public void OnPickUp(GameObject picker)
    {
        SC_PlayerController.instance.ChangePower(powerValue);
        Debug.Log("Picked up fruit, power increased by " + powerValue);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnPickUp(collision.gameObject);
 
        }
    }
}
