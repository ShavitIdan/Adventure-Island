using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;


    private void Awake()
    {
        init();
    }


    protected virtual void init()
    {
        Debug.Log("Enemy initialized.");
    }

    protected abstract void move();
    protected abstract void attack();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    public void takeDamage(float damage)
    {
        die();
    }

    protected virtual void die()
    {
        Debug.Log("Enemy died.");
        gameObject.SetActive(false);
    }
}
