using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Boomerang : MonoBehaviour
{
    private float speed = 6f;
    private float lifeTime = 2.5f;
    private bool isReturning = false;
    private Vector3 startPosition;
    private Vector3 returnTarget;

    public Action OnBoomerangDeactivate;
  
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void Shoot(float direction)
    {
        transform.localScale = new Vector3(direction, 1, 1);
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector2(speed * direction, 5f);
        startPosition = transform.position;
        returnTarget = startPosition;
        StartCoroutine(DeactivateLogic());
    }

    private IEnumerator DeactivateLogic()
    {
        yield return new WaitForSeconds(lifeTime / 2);
        StartReturning();
        yield return new WaitForSeconds(lifeTime / 2);
        DeactivateObject();
    }

    private void StartReturning()
    {
        isReturning = true;
    }

    private void FixedUpdate()
    {
        if (isReturning)
        {
            Vector3 direction = (returnTarget - transform.position).normalized;
            Rigidbody2D rigid = GetComponent<Rigidbody2D>();
            rigid.velocity = direction * speed;

            if (Vector3.Distance(transform.position, returnTarget) < 0.1f)
            {
                DeactivateObject();
            }
        }
    }

    private void DeactivateObject()
    {
        OnBoomerangDeactivate?.Invoke();
        Destroy(gameObject);
    }

    public void Initialize(float newSpeed, float newLifeTime)
    {
        speed = newSpeed;
        lifeTime = newLifeTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>()?.takeDamage(1);
            DeactivateObject();
        }

        if (collision.gameObject.tag == "Ground")
        {
            DeactivateObject();
        }

        // If the boomerang hits the player, deactivate it
        if (collision.gameObject.tag == "Player" && isReturning)
        {
            DeactivateObject();
        }
    }
}
