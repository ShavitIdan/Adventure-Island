using System;
using UnityEngine;

public class SC_Fruit : MonoBehaviour, IPickAble
{
    private static int fruitCount = 0;
    static public Action OnFruitPickedUp;
    private const int fruitsForExtraLife = 30;
    public int powerValue = 3;
    
    static public int getFruitCount()
    {
        return fruitCount;
    }
    public void OnPickUp(GameObject picker)
    {
        SC_PlayerController.instance.ChangePower(powerValue);
        Debug.Log("Picked up fruit, power increased by " + powerValue);
        fruitCount++;
        if (fruitCount >= fruitsForExtraLife)
        {
            SC_PlayerController.instance.lifeController.GainLife();
            fruitCount = 0;
        }
        OnFruitPickedUp?.Invoke();
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
